using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VocDbContext.DataAccessLayers;

namespace VocDbContext
{
    public class VocDataAccess : UsersDataAccess
    {

        List<string> strs;
   
      
        //return all voc with its defination
        protected List<Vocabularys> ReturnVocublarys()
        {

            myDbContext = new VocabularyDbContext();

            vocabularys = new List<Vocabularys>();
           
            vocabulary = new Vocabularys();

            myDbContext.Vocabularys.ToList();
            var result = myDbContext.Vocabularys.ToList(); 
            if (result.Count > 0)
            {
                foreach (Vocabularys voc in result)
                {
                    vocabulary.vocabulary = voc.vocabulary;
                    vocabulary.vocabularyID = voc.vocabularyID;
                    vocabulary.Definitions = ReturnDefinatins(vocabulary.vocabularyID);
                }
                return myDbContext.Vocabularys.ToList();
            }
            else
            {
                return null;
            }
        }        
        //Return vocabulary by user id
        public List<Vocabularys> ReturnVocublarys(int userId, string userName)
        {
            if (IsNullOrValue(userId) == true)
            {
                if (userName == UserExist(userId))
                {
                    vocabularys = new List<Vocabularys>();
                    myDbContext = new VocabularyDbContext();

                    var result = (from voc in myDbContext.Vocabularys.ToList()
                                  where voc.UserID == userId
                                  select voc).ToList();

                    foreach (Vocabularys vr in result)
                    {
                        vocabulary = new Vocabularys();
                        vocabulary.UserID = vr.UserID;
                        vocabulary.vocabularyID = vr.vocabularyID;
                        vocabulary.vocabulary = vr.vocabulary;
                        vocabulary.vocPoint = vr.vocPoint;
                        vocabulary.Definitions = ReturnDefinatins(vocabulary.vocabularyID);
                        vocabularys.Add(vocabulary);
                    }
                }
                


            }
            return vocabularys;
        }       
        //return sing voc
        public List<Vocabularys> ReturnVocublarys(int userId,string username, string myvoc) 
        {
            vocabularys = new List<Vocabularys>();
            myDbContext = new VocabularyDbContext();
            var result = (from voc in myDbContext.Vocabularys.ToList()
                          where voc.UserID == userId && voc.vocabulary == myvoc
                          select voc).ToList();
            foreach (Vocabularys vr in result)
            {
                vocabulary = new Vocabularys();
                vocabulary.UserID = vr.UserID;
                vocabulary.vocabularyID = vr.vocabularyID;
                vocabulary.vocabulary = vr.vocabulary;
                vocabulary.Definitions = ReturnDefinatins(vocabulary.vocabularyID);
                vocabularys.Add(vocabulary);
            }
            return vocabularys;
        }       
        //return defination
        protected List<Definitions> ReturnDefinations(int vocId)
        {
            definitions = new List<Definitions>();
            myDbContext = new VocabularyDbContext();
            var result = (from def in myDbContext.Definitions.ToList()
                          where def.vocabularyID == vocId
                          select def).ToList();
            foreach (Definitions def in result)
            {
                definition = new Definitions();
                definition = def;
                //definition.definition = def.definition;
                definitions.Add(definition);
            }
            return definitions;
        }
        // return defination by foregin key
        protected List<Definitions> ReturnDefinatins(int vocID)
        {
            definitions = new List<Definitions>();

            myDbContext = new VocabularyDbContext();

            var definationResult = from defResult in myDbContext.Definitions.ToList()
                                   where defResult.vocabularyID == vocID
                                   select defResult;

            if (definationResult.Count() > 0)
            {
                foreach (Definitions def in definationResult)
                {
                    definition = new Definitions();
                    definition.definition = def.definition;
                    definitions.Add(definition);
                }
                return definitions;
            }
            else
            {
                return null;
            }
        }
        //Perform voc exist
        //return true if exis
        protected bool VocabularyExist(string voc)
        {
            myDbContext = new VocabularyDbContext();
            var count = (from c in myDbContext.Vocabularys
                         where c.vocabulary == voc
                         select c.vocabulary).Count();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Perform voc exist
        //return true if exis by user
        protected bool VocabularyExist(string voc, int userid)
        {
            myDbContext = new VocabularyDbContext();
            var count = (from c in myDbContext.Vocabularys
                         where c.vocabulary == voc & c.UserID== userid
                         select c.vocabulary).Count();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }      
        //Insert vocublary
        //return true if sucessced
        protected bool InsertVocublary(Vocabularys vocabulary)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    myDbContext.Vocabularys.Add(vocabulary);
                    int x = myDbContext.SaveChanges();

                    if (x >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
            return true;
        }
        //Perform insert definations by foreign key 
        // return true or false
        protected bool InsertDefination(Definitions defination)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    myDbContext.Definitions.Add(defination);
                    //int x = myDbContext.SaveChanges();
                    //if (x >= 1)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
            return true;

        }
        // Update vocublary point
        // return true or false        
        protected bool UpdateVocublary(int vocPoint)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    vocabulary = myDbContext.Vocabularys.First(v => v.vocPoint == vocPoint);
                    vocabulary.vocPoint = vocPoint;
                    int x = myDbContext.SaveChanges();
                    if (x >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
        }        
        // Update vocublary
        //return true or false        
        protected bool UpdateVocublary(int vocid, string newVoc)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    vocabulary = myDbContext.Vocabularys.First(v => v.vocabularyID == vocid);                 
                    

                    vocabulary.vocabulary = newVoc;
                    int x = myDbContext.SaveChanges();
                    if (x >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
        }
        //update defination
        protected bool UpdateDefination(int defID, string newDef)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    definition = myDbContext.Definitions.First(d => d.vocabularyID == defID);
                    
                    definition.definition = newDef;
                    int x = myDbContext.SaveChanges();
                    if (x >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
        }
        // vocublary by its id
        // return true or false        
        protected bool DeleteVocublary(int vocublaryID)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    Vocabularys vocabulary = (from voc in myDbContext.Vocabularys
                                              where voc.vocabularyID == vocublaryID
                                              select voc).FirstOrDefault();
                    //  vocDbContext.Vocabularys.Del
                    return true;
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
        }
        //Return voc ids by user id
        protected List<int> ReturnVocublaryID(int userID)
        {
            List<int> vocIDs = new List<int>();
            myDbContext = new VocabularyDbContext();

            var result = (from voc in myDbContext.Vocabularys.ToList()
                          where voc.UserID == userID
                          select voc.vocabularyID).ToList();
            foreach (var vocID in result)
            {
                vocIDs.Add(vocID);
            }
            return vocIDs;
        }
        //Return dates
        protected List<DateTime> ReturnDate(int userID)
        {
            List<DateTime> listDates = new List<DateTime>();
            return listDates;
        }

        //
    }
}









