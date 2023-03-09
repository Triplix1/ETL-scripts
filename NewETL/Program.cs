namespace NewETL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdisContext ctx = new AdisContext();

            //TransformCondition();
            //TransformCountriesNamesInMainDataSet();
            //TransformCountryNames();

            //LoadSallers();
            //LoadGenders();
            //LoadConditions();
            //LoadColors();
            //LoadDates();
            //LoadCountries();
            //LoadDimBrands();
            //LoadFactCovid();
            //LoadFactCarSale();

            #region Update
            void UpdateCountry()
            {
                TransformCountriesNamesInMainDataSet();
                DimCountry country;
                foreach (var item in ctx.StageCountries)
                {
                    country = ctx.DimCountries.FirstOrDefault(x => x.CountryCode == item.CountryCode);
                    if (country == null)
                    {
                        ctx.DimCountries.Add(new DimCountry
                        {
                            CountryCode = item.CountryCode,
                            Name = item.Name,
                            Population = item.Population,
                        });
                        ctx.SaveChanges();
                    }
                    else if (country.Name != item.Name)
                    {
                        country.Name = item.Name;
                        ctx.SaveChanges();
                    }
                }
            }

            #endregion

            #region Transform

            void TransformCountryNames()
            {
                foreach (var item in ctx.StageBrands)
                {
                    if (item.Country == "USA")
                    {
                        item.Country = "United States";
                    }
                    else if (item.Country == "Korea")
                    {
                        item.Country = "Korea, Dem. Rep.";
                    }
                    else if (item.Country == "UK")
                    {
                        item.Country = "United Kingdom";
                    }
                    else if (item.Country == "Italia")
                    {
                        item.Country = "Italy";
                    }
                }

                foreach (var item in ctx.StageCarSales)
                {
                    switch (item.Country)
                    {
                        case "Cape Verde":
                            item.Country = "Cabo Verde";
                            break;
                        case "Republic of the Congo":
                            item.Country = "Congo, Rep.";
                            break;
                        case "Democratic Republic of the Congo":
                            item.Country = "Congo, Dem. Rep.";
                            break;
                        case "South Korea":
                            item.Country = "Korea, Rep.";
                            break;
                        case "North Korea":
                            item.Country = "Korea, Dem. Rep.";
                            break;
                    }   
                }               

                foreach (var item in ctx.StageCovids)
                {
                    switch (item.Country)
                    {
                        case "Congo (Brazzaville)":
                            item.Country = "Congo, Rep.";
                            break;
                        case "Congo (Kinshasa)":
                            item.Country = "Congo, Dem. Rep.";
                            break;
                        case "Czechia":
                            item.Country = "Czech Republic";
                            break;
                        case "Korea, South":
                            item.Country = "Korea, Rep.";
                            break;
                        case "North Macedonia":
                            item.Country = "Macedonia";
                            break;
                        case "US":
                            item.Country = "United States";
                            break;
                    }
                }

                ctx.SaveChanges();
            }

            void TransformCountriesNamesInMainDataSet()
            {
                ctx.StageCountries.Where(x => x.Name == "Gambia, The").FirstOrDefault().Name = "Gambia";
                ctx.StageCountries.Where(x => x.Name == "Hong Kong SAR, China").FirstOrDefault().Name = "Hong Kong";
                ctx.StageCountries.Where(x => x.Name == "Iran, Islamic Rep.").FirstOrDefault().Name = "Iran";
                ctx.StageCountries.Where(x => x.Name == "Macedonia, FYR").FirstOrDefault().Name = "Macedonia";
                ctx.StageCountries.Where(x => x.Name == "Micronesia, Fed. Sts.").FirstOrDefault().Name = "Micronesia";
                ctx.StageCountries.Where(x => x.Name == "Slovak Republic").FirstOrDefault().Name = "Slovakia";
                ctx.StageCountries.Where(x => x.Name == "Syrian Arab Republic").FirstOrDefault().Name = "Syria";
                ctx.StageCountries.Where(x => x.Name == "Venezuela, RB").FirstOrDefault().Name = "Venezuela";
                ctx.StageCountries.Where(x => x.Name == "Yemen, Rep.").FirstOrDefault().Name = "Yemen";
                ctx.StageCountries.Where(x => x.Name == "Bahamas, The").FirstOrDefault().Name = "Bahamas";
                ctx.StageCountries.Where(x => x.Name == "Brunei Darussalam").FirstOrDefault().Name = "Brunei";
                ctx.StageCountries.Where(x => x.Name == "Egypt, Arab Rep.").FirstOrDefault().Name = "Egypt";
                ctx.StageCountries.Where(x => x.Name == "Kyrgyz Republic").FirstOrDefault().Name = "Kyrgyzstan";
                ctx.StageCountries.Where(x => x.Name == "Lao PDR").FirstOrDefault().Name = "Laos";
                ctx.StageCountries.Where(x => x.Name == "Russian Federation").FirstOrDefault().Name = "Russia";

                ctx.SaveChanges();
            }

            void TransformCondition()
            {
                foreach (var item in ctx.StageCarSales)
                {
                    if (item.NewCar == "True")
                    {
                        item.NewCar = "New";
                    }
                    else
                    {
                        item.NewCar = "Used";
                    }
                }
                ctx.SaveChanges();
            }
            
            #endregion

            #region Load

            //Load Sallers
            void LoadSallers()
            {
                long i = 1;
                DimSaller saller;
                List<DimSaller> sallers = new List<DimSaller>();
                foreach (var item in ctx.StageCarSales)
                {
                    saller = new DimSaller
                    {
                        Name = item.SellerNickname,
                        Id = i++
                    };

                    if (!sallers.Contains(saller,new SallerEqualityComparer()))
                    {
                        sallers.Add(saller);
                    }
                }

                ctx.DimSallers.AddRange(sallers);

                ctx.SaveChanges();
            }

            void LoadGenders()
            {
                ctx.DimGenders.Add(new DimGender { Id = 1, Gender = "Female" });
                ctx.DimGenders.Add(new DimGender { Id = 2, Gender = "Male" });
                ctx.SaveChanges();
            }

            void LoadConditions()
            {
                ctx.DimConditions.Add(new DimCondition
                {
                    Condition = "New",
                    Id = 1
                });

                ctx.DimConditions.Add(new DimCondition
                {
                    Condition = "Used",
                    Id = 2
                });

                ctx.SaveChanges();
            }

            void LoadColors()
            {
                var id = 1;
                DimColor color;
                List<DimColor> colors = new List<DimColor>();
                foreach (var item in ctx.StageCarSales)
                {
                    color = new DimColor
                    {
                        ColorName = item.Color,
                        Id = id++
                    };

                    if (!colors.Contains(color,new ColorEqualityComparer()))
                    {
                        colors.Add(color);
                    }
                }

                ctx.DimColors.AddRange(colors);

                ctx.SaveChanges();
            }

            void LoadDates()
            {
                int id = 1;
                DimDate date;
                var dates = new List<DimDate>();
                var comparer = new DateEqualityComparer();
                foreach (var item in ctx.StageCarSales)
                {
                    date = new DimDate
                    {
                        Id = id++,
                        Day = (short)item.PurchaseDate.Day,
                        Month = (short)item.PurchaseDate.Month,
                        Year = item.PurchaseDate.Year
                    };

                    if (!dates.Contains(date,comparer))
                    {
                        dates.Add(date); 
                    }                    
                }

                foreach (var item in ctx.StageCovids)
                {
                    date = new DimDate
                    {
                        Id = id++,
                        Day = (short)item.Date.Day,
                        Month = (short)item.Date.Month,
                        Year = item.Date.Year
                    };

                    if (!dates.Contains(date, comparer))
                    {
                        dates.Add(date);
                    }
                }

                ctx.DimDates.AddRange(dates);

                ctx.SaveChanges ();
            }

            void LoadCountries()
            {
                ctx.DimCountries.AddRange(ctx.StageCountries.ToList().Select((x,index) => new DimCountry
                {
                    Id = x.Id,
                    Name = x.Name,
                    Population = x.Population,
                    CountryCode = x.CountryCode
                }).DistinctBy(x => x.Name));

                ctx.SaveChanges();
            }

            void LoadDimBrands()
            {
                foreach (var item in ctx.StageBrands.ToList())
                {
                    var country = FindCountry(item.Country);

                    if (country != null)
                    {
                        ctx.DimBrands.Add(new DimBrand
                        {
                            Id = item.Id,
                            CountryId = country.Id,
                            Name = item.Name,
                            Founded = item.Founded,
                        });                  
                    }
                }
                ctx.SaveChanges();
            }

            void LoadFactCovid()
            {
                int id = 1;
                foreach(var item in ctx.StageCovids.ToList())
                {
                    var country = FindCountry(item.Country);
                    var date = FindDate(item.Date);

                    if (country != null && date != null)
                    {
                        ctx.FactCovids.Add(new FactCovid
                        {
                            Id = id++,
                            DateId = date.Id,
                            CountryId = country.Id,
                            Cases = item.Cases,
                            CaseType = item.CaseType
                        });
                    }                    
                }

                ctx.SaveChanges();
            }

            void LoadFactCarSale()
            {
                foreach (var item in ctx.StageCarSales.ToList())
                {
                    var country = FindCountry(item.Country);
                    var date = FindDate(item.PurchaseDate);
                    var brand = FindBrand(item.Make);
                    var color = FindColor(item.Color);
                    var condition = FindCondition(item.NewCar);
                    var carGender = FindGender(item.CarGender);
                    var buyerGender = FindGender(item.BuyerGender);
                    var saller = FindSaller(item.SellerNickname);

                    if (country != null && date != null && brand != null && color != null && condition != null && carGender != null && buyerGender != null && saller != null)
                    {
                        ctx.FactCarSales.Add(new FactCarSale
                        {
                            Id = item.Id,
                            BuyerAge = item.BuyerAge,
                            BuyerGenderId = buyerGender.Id,
                            CarBrandId = brand.Id,
                            SellerId = saller.Id,
                            CarGenderId = carGender.Id,
                            CountryId = country.Id,
                            CarConditionId = condition.Id,
                            ColorId = color.Id,
                            DateId = date.Id,
                            CarModel = item.Model,
                            Price = item.SalePrice,
                            MaxSpeed = item.MaxSpeed
                        });
                    }
                }
                ctx.SaveChanges();
            }

            DimCountry? FindCountry(string countryName)
            {
                return ctx.DimCountries.FirstOrDefault(x => x.Name == countryName);
            }

            DimDate? FindDate(DateTime date)
            {
                return ctx.DimDates.FirstOrDefault(x => x.Day == date.Day && x.Year == date.Year && x.Month == date.Month);
            }

            DimBrand? FindBrand(string name)
            {
                return ctx.DimBrands.FirstOrDefault(x => x.Name == name);
            }

            DimColor? FindColor(string color)
            {
                return ctx.DimColors.FirstOrDefault(x => x.ColorName == color);
            }

            DimCondition? FindCondition(string condition)
            {
                return ctx.DimConditions.FirstOrDefault(x => x.Condition == condition);
            }

            DimGender? FindGender(string gender)
            {
                return ctx.DimGenders.FirstOrDefault(x => x.Gender == gender);
            }

            DimSaller? FindSaller(string saller)
            {
                return ctx.DimSallers.FirstOrDefault(x => x.Name == saller);
            }
            #endregion
        }
    }
}