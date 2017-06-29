using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocDbContext;
using VocDbContext.DataAccessLayers;

namespace VocBusinessLayer
{

    public class BusinessLayers : VocDataAccess
    {

        int sortVal;
        Object obj;
        Array array;
        ArrayList myArrayList;
        BusinessLayers bussines;
        Vocabularys myVoc;
        List<int> vocPoints;
        //Test purp
        //Default return everything
        public ArrayList UserLogin()
        {
            myArrayList = new ArrayList();
            bussines = new BusinessLayers();
            myArrayList.Add(bussines.returnUsers().ToList());
            return myArrayList;
        }
        //user login
        public ArrayList userLogin(string username, string password)
        {
            myArrayList = new ArrayList();
            user = new Users();

            if (UserExist(username) == true)
            {

                vocabulary = new Vocabularys();
                definition = new Definitions();

                bussines = new BusinessLayers();
                user = bussines.ReturnUser(username, password);
                user.Vocabularys = bussines.ReturnVocublarys(user.UserID, user.UserName);

                vocabulary.Definitions = bussines.ReturnDefinations(vocabulary.vocabularyID);
                myArrayList.Add(user);
            }
            else
            {
                user.UserName = "invalid";
                myArrayList.Add(user);

            }
            return myArrayList;
        }
        //User signp
        public string UserSignUp(Users user)
        {
            string conferm = "";

            bussines = new BusinessLayers();
            bool userName = bussines.UserExist(user.UserName);
            bool userEmail = bussines.EmailExist(user.UserEmail);

            if ((userName == false) && (userEmail == false))
            {
                //dataAcess.AddUser(user);

                if (bussines.AddUser(user) == true)
                {
                    conferm = "Creatring User Successed!";
                    return conferm;
                }
                else
                {
                    return " ";
                }
            }
            else
            {
                if (userName == true)
                {
                    conferm = "Uesername Inuse !";
                }


                if (userEmail == true)
                {
                    conferm = "Email inuse!";

                }

            }
            return conferm;
        }
        //Test purp
        //return all voc
        public ArrayList RturnAllVocublarys()
        {
            myArrayList = new ArrayList();

            bussines = new BusinessLayers();

            myArrayList.Add(bussines.ReturnVocublarys());

            return myArrayList;

        }
        //return all voc by uer id
        public ArrayList RturnAllVocublarys(int userID, string userName)
        {
            if (userID != 0)
            {
                myArrayList = new ArrayList();

                bussines = new BusinessLayers();

                myArrayList.Add(bussines.ReturnVocublarys(userID, userName));


            }


            return myArrayList;
        }
        //insert new Voc
        public ArrayList AddMyVocublary(Vocabularys voc)
        {
            if (voc.UserID != 0)
            {
                myArrayList = new ArrayList();
                bool result;
                bussines = new BusinessLayers();
                int userid = voc.UserID;
                string vocs = voc.vocabulary;

                //check voc esist
                result = bussines.VocabularyExist(vocs, userid);

                if (result == false)
                {
                    //add
                    bussines.InsertVocublary(voc);
                    int newVocID = voc.vocabularyID;
                    definition = new Definitions();
                    definition.vocabularyID = newVocID;
                    definition.definition = voc.Definitions[0].definition;

                    if (definition.definition == null)
                    {
                        definition.definition = "def not provide";
                        InsertDef(definition);
                    }
                    else
                    {
                        InsertDef(definition);
                    }

                }
                else
                {
                    //return the existing voc ID if voc exist
                    var resultVoc = from r in bussines.ReturnVocublarys(userid, vocs)
                                    select new { vo = r.vocabulary, voi = r.vocabularyID };
                    myArrayList.Add(resultVoc.ToList());

                }
            }
            return myArrayList;
        }
        //update voucublary
        public void UpdateVocublarys(int id, string voc)
        {
            bussines = new BusinessLayers();
            bussines.UpdateVocublary(id, voc);
        }
        //udate defination
        public void UpdateDefinations(int defID, string newDef)
        {
            bussines = new BusinessLayers();
            bussines.UpdateDefination(defID, newDef);

        }

        //Inset def 
        public void InsertDef(Definitions def)
        {
            if (def.vocabularyID != 0 && def.vocabularyID != null)
            {
                bussines = new BusinessLayers();
                bussines.InsertDefination(def);
            }

        }


    }
}
