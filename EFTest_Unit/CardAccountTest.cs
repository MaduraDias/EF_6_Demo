using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EF_Test;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Threading;

namespace EFTest_Unit
{
    [TestClass]
    public class CardAccountTest
    {
        [TestInitialize]
        public void StartUp()
        {
            using (var context = new CardAccountDBContext())
            {
                context.Account.Add(
                    new Account()
                    {
                        Cards = new List<Card>()
                         {
                              new Card()
                              {
                                    CardDesign =new CardDesign()
                                    {
                                         CardDesignName ="ChristmasDesign"
                                    },

                                    Cardholder=new Cardholder()
                                    {
                                         Name="Madura",
                                          DateOfBirth =DateTime.Today
                                    },

                                    CardNumber ="11111111"
                               }
                                  ,

                              new Card()
                              {
                                    CardDesign =new CardDesign()
                                    {
                                         CardDesignName ="MotherdayDesign"
                                    },

                                    Cardholder=new Cardholder()
                                    {
                                         Name="Dias",
                                          DateOfBirth =DateTime.Today
                                    },

                                    CardNumber ="11111112"

                              }

                         }
                    }
                    );


                context.Account.Add(
                    new Account()
                    {
                        Cards = new List<Card>()
                         {
                              new Card()
                              {
                                    CardDesign =new CardDesign()
                                    {
                                         CardDesignName ="ChristmasDesign"
                                    },

                                    Cardholder=new Cardholder()
                                    {
                                         Name="Madura",
                                          DateOfBirth =DateTime.Today
                                    },

                                    CardNumber ="11111111"
                               }
                                  ,

                              new Card()
                              {
                                    CardDesign =new CardDesign()
                                    {
                                         CardDesignName ="MotherdayDesign"
                                    },

                                    Cardholder=new Cardholder()
                                    {
                                         Name="Dias",
                                          DateOfBirth =DateTime.Today
                                    },

                                    CardNumber ="11111112"

                              }

                         }
                    }
                    );

                context.Account.Add(
                    new Account()
                    {
                        Cards = new List<Card>()
                         {
                              new Card()
                              {
                                    CardDesign =new CardDesign()
                                    {
                                         CardDesignName ="ChristmasDesign"
                                    },

                                    Cardholder=new Cardholder()
                                    {
                                         Name="Madura",
                                          DateOfBirth =DateTime.Today
                                    },

                                    CardNumber ="11111111"
                               }
                                  ,

                              new Card()
                              {
                                    CardDesign =new CardDesign()
                                    {
                                         CardDesignName ="MotherdayDesign"
                                    },

                                    Cardholder=new Cardholder()
                                    {
                                         Name="Dias",
                                          DateOfBirth =DateTime.Today
                                    },

                                    CardNumber ="11111112"

                              }

                         }
                    }
                    );
                context.SaveChanges();

            }
        }

        #region  Demo

        //Virtual Properties
        //Lazy Loading
        //Eager Loading
        //Explicit Loading
        //Proxy Enabled

        [TestMethod]
        public void ReadTest()
        {
            using (var context = new CardAccountDBContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var account = context.Account.Where(x => x.AccountId == 1).FirstOrDefault();

                //var account = context.Account.Where(x => x.AccountId == 1)
                //    .Include(x => x.Cards)
                //    .Include(x => x.Cards.Select(y => y.CardDesign))
                //    .Include(x => x.Cards.Select(z => z.Cardholder))
                //    .FirstOrDefault();


                context.Entry<Account>(account)
                 .Collection(X => X.Cards)
                 .Query()
                 .Include(X=>X.CardDesign)
                 .Include(X=>X.Cardholder)
                 .Load();
                 

                foreach (var card in account.Cards)
                {
                    var cardDesign = card.CardDesign;
                    var cardholder = card.Cardholder;
                }
            }
        }

        #endregion


        #region Thread Test

        // [TestMethod]
        public void TestLazyLoading()
        {
            //Show virtual
            //Show Lazy Loading
            //Show Eager Loading
            //Show Explicit Loading
            //Disable Proxy
            var thread1 = new Thread(() => Read(1));

            var thread2 = new Thread(() => Read(2));
            var thread3 = new Thread(() => Read(3));

            thread1.Start();
            //   thread2.Start();
            //  thread3.Start();

            // Read(1);
        }


        private void Read(long accId)
        {
            using (var context = new CardAccountDBContext())
            {
                context.Configuration.LazyLoadingEnabled = true;
                //   context.Configuration.ProxyCreationEnabled = false;

                try
                {

                    var account = context.Account.Where(x => x.AccountId == accId).SingleOrDefault();


                    foreach (var card in account.Cards)
                    {
                        Debug.WriteLine("Enter loop");
                        var cardDesign = card.CardDesign;
                        var cardholder = card.Cardholder;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

                // Eager loading======================================================

                //var account = context.Account
                // .Where(X => X.AccountId == 1)
                // .Include(x => x.Cards)
                // .Include(x => x.Cards.Select(a => a.CardDesign))
                // .Include(x => x.Cards.Select(z => z.Cardholder))
                // .SingleOrDefault();

                //===================================================================


                //Explicit Loading==============================================
                //var account = context.Account.Where(x => x.AccountId == 1).FirstOrDefault();

                //context.Entry<Account>(account)
                //    .Collection(x => x.Cards)
                //    .Query()
                //    .Include(x=>x.CardDesign)
                //    .Include(x=>x.Cardholder)
                //    .Load();
                //Explicit Loading End==============================================



            }
        }

        #endregion

    }

}
