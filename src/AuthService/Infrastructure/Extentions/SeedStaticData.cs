using Domain.Common;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Extensions
{
    public class SeedStaticData
    {
        private readonly ILogger<SeedStaticData> _logger;

        public SeedStaticData(ILogger<SeedStaticData> logger)
        {
            _logger = logger;
        }

        public async Task SeedStaticDataAsync(AuthDbContext context)
        {
            _logger.LogInformation("Starting static data seeding...");

            try
            {
                var statusValues = new List<string> { "Active", "Disabled" };
                foreach (var status in statusValues)
                {
                    if (!context.StaticData.Any(sd => sd.Key == "Status" && sd.Value == status))
                    {
                        var statusData = new StaticData
                        {
                            Key = "Status",
                            Value = status,
                            Description = $"Represents a {status} status",
                            Sts = "Active"
                        };

                        await context.StaticData.AddAsync(statusData);
                        _logger.LogInformation($"Inserted Status: {status}");
                    }
                }

                var genderValues = new List<string> { "Male", "Female", "Other" };
                foreach (var gender in genderValues)
                {
                    if (!context.StaticData.Any(sd => sd.Key == "Gender" && sd.Value == gender))
                    {
                        var genderData = new StaticData
                        {
                            Key = "Gender",
                            Value = gender,
                            Description = $"Represents {gender} gender",
                            Sts = "Active"
                        };

                        await context.StaticData.AddAsync(genderData);
                        _logger.LogInformation($"Inserted Gender: {gender}");
                    }
                }

                // Nepal Provinces
                var provinces = new List<StaticData>
                {
                    new() { Key = "Province", Value = "Province No. 1", Description = "Eastern province of Nepal", Sts = "Active" },
                    new() { Key = "Province", Value = "Province No. 2", Description = "Southern province of Nepal", Sts = "Active" },
                    new() { Key = "Province", Value = "Bagmati", Description = "Province No. 3 of Nepal", Sts = "Active" },
                    new() { Key = "Province", Value = "Gandaki", Description = "Province No. 4 of Nepal", Sts = "Active" },
                    new() { Key = "Province", Value = "Lumbini", Description = "Province No. 5 of Nepal", Sts = "Active" },
                    new() { Key = "Province", Value = "Karnali", Description = "Province No. 6 of Nepal", Sts = "Active" },
                    new() { Key = "Province", Value = "Sudurpashchim", Description = "Province No. 7 of Nepal", Sts = "Active" }
                };

                // Nepal Districts (all 77)
                var districts = new List<(string Province, string District, string Description)>
                {
                    ("Province No. 1", "Bhojpur", "District in Province No. 1"),
                    ("Province No. 1", "Dhankuta", "District in Province No. 1"),
                    ("Province No. 1", "Ilam", "District in Province No. 1"),
                    ("Province No. 1", "Jhapa", "District in Province No. 1"),
                    ("Province No. 1", "Khotang", "District in Province No. 1"),
                    ("Province No. 1", "Morang", "District in Province No. 1"),
                    ("Province No. 1", "Okhaldhunga", "District in Province No. 1"),
                    ("Province No. 1", "Panchthar", "District in Province No. 1"),
                    ("Province No. 1", "Sankhuwasabha", "District in Province No. 1"),
                    ("Province No. 1", "Solukhumbu", "District in Province No. 1"),
                    ("Province No. 1", "Sunsari", "District in Province No. 1"),
                    ("Province No. 1", "Taplejung", "District in Province No. 1"),
                    ("Province No. 1", "Terhathum", "District in Province No. 1"),
                    ("Province No. 1", "Udayapur", "District in Province No. 1"),
                    ("Province No. 2", "Bara", "District in Province No. 2"),
                    ("Province No. 2", "Dhanusa", "District in Province No. 2"),
                    ("Province No. 2", "Mahottari", "District in Province No. 2"),
                    ("Province No. 2", "Parsa", "District in Province No. 2"),
                    ("Province No. 2", "Rautahat", "District in Province No. 2"),
                    ("Province No. 2", "Saptari", "District in Province No. 2"),
                    ("Province No. 2", "Sarlahi", "District in Province No. 2"),
                    ("Province No. 2", "Siraha", "District in Province No. 2"),
                    ("Bagmati", "Bhaktapur", "District in Bagmati Province"),
                    ("Bagmati", "Chitwan", "District in Bagmati Province"),
                    ("Bagmati", "Dhading", "District in Bagmati Province"),
                    ("Bagmati", "Dolakha", "District in Bagmati Province"),
                    ("Bagmati", "Kathmandu", "District in Bagmati Province"),
                    ("Bagmati", "Kavrepalanchok", "District in Bagmati Province"),
                    ("Bagmati", "Lalitpur", "District in Bagmati Province"),
                    ("Bagmati", "Makwanpur", "District in Bagmati Province"),
                    ("Bagmati", "Nuwakot", "District in Bagmati Province"),
                    ("Bagmati", "Ramechhap", "District in Bagmati Province"),
                    ("Bagmati", "Rasuwa", "District in Bagmati Province"),
                    ("Bagmati", "Sindhuli", "District in Bagmati Province"),
                    ("Bagmati", "Sindhupalchok", "District in Bagmati Province"),
                    ("Gandaki", "Baglung", "District in Gandaki Province"),
                    ("Gandaki", "Gorkha", "District in Gandaki Province"),
                    ("Gandaki", "Kaski", "District in Gandaki Province"),
                    ("Gandaki", "Lamjung", "District in Gandaki Province"),
                    ("Gandaki", "Manang", "District in Gandaki Province"),
                    ("Gandaki", "Mustang", "District in Gandaki Province"),
                    ("Gandaki", "Myagdi", "District in Gandaki Province"),
                    ("Gandaki", "Nawalpur", "District in Gandaki Province"),
                    ("Gandaki", "Parbat", "District in Gandaki Province"),
                    ("Gandaki", "Syangja", "District in Gandaki Province"),
                    ("Gandaki", "Tanahun", "District in Gandaki Province"),
                    ("Lumbini", "Arghakhanchi", "District in Lumbini Province"),
                    ("Lumbini", "Banke", "District in Lumbini Province"),
                    ("Lumbini", "Bardiya", "District in Lumbini Province"),
                    ("Lumbini", "Dang", "District in Lumbini Province"),
                    ("Lumbini", "Eastern Rukum", "District in Lumbini Province"),
                    ("Lumbini", "Gulmi", "District in Lumbini Province"),
                    ("Lumbini", "Kapilvastu", "District in Lumbini Province"),
                    ("Lumbini", "Parasi", "District in Lumbini Province"),
                    ("Lumbini", "Palpa", "District in Lumbini Province"),
                    ("Lumbini", "Pyuthan", "District in Lumbini Province"),
                    ("Lumbini", "Rolpa", "District in Lumbini Province"),
                    ("Lumbini", "Rupandehi", "District in Lumbini Province"),
                    ("Karnali", "Dailekh", "District in Karnali Province"),
                    ("Karnali", "Dolpa", "District in Karnali Province"),
                    ("Karnali", "Humla", "District in Karnali Province"),
                    ("Karnali", "Jajarkot", "District in Karnali Province"),
                    ("Karnali", "Jumla", "District in Karnali Province"),
                    ("Karnali", "Kalikot", "District in Karnali Province"),
                    ("Karnali", "Mugu", "District in Karnali Province"),
                    ("Karnali", "Salyan", "District in Karnali Province"),
                    ("Karnali", "Surkhet", "District in Karnali Province"),
                    ("Karnali", "Western Rukum", "District in Karnali Province"),
                    ("Sudurpashchim", "Achham", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Baitadi", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Bajhang", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Bajura", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Dadeldhura", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Darchula", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Doti", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Kailali", "District in Sudurpashchim Province"),
                    ("Sudurpashchim", "Kanchanpur", "District in Sudurpashchim Province")
                };

                // Nepal Major Cities (all 77 districts, one or more major cities/municipalities per district)
                var cities = new List<(string District, string City, string Description)>
                {
                    // Province No. 1
                    ("Bhojpur", "Bhojpur", "Major city in Bhojpur"),
                    ("Dhankuta", "Dhankuta", "Major city in Dhankuta"),
                    ("Ilam", "Ilam", "Major city in Ilam"),
                    ("Jhapa", "Birtamode", "Major city in Jhapa"),
                    ("Jhapa", "Damak", "City in Jhapa district"),
                    ("Jhapa", "Mechinagar", "City in Jhapa district"),
                    ("Khotang", "Diktel", "Major city in Khotang"),
                    ("Morang", "Biratnagar", "Major city in Morang"),
                    ("Morang", "Urlabari", "City in Morang district"),
                    ("Morang", "Rangeli", "City in Morang district"),
                    ("Okhaldhunga", "Okhaldhunga", "Major city in Okhaldhunga"),
                    ("Panchthar", "Phidim", "Major city in Panchthar"),
                    ("Sankhuwasabha", "Khandbari", "Major city in Sankhuwasabha"),
                    ("Solukhumbu", "Salleri", "Major city in Solukhumbu"),
                    ("Sunsari", "Inaruwa", "Major city in Sunsari"),
                    ("Sunsari", "Itahari", "City in Sunsari district"),
                    ("Sunsari", "Dharan", "City in Sunsari district"),
                    ("Taplejung", "Taplejung", "Major city in Taplejung"),
                    ("Terhathum", "Myanglung", "Major city in Terhathum"),
                    ("Udayapur", "Gaighat", "Major city in Udayapur"),
                    // Province No. 2
                    ("Bara", "Kalaiya", "Major city in Bara"),
                    ("Bara", "Simraungadh", "City in Bara district"),
                    ("Dhanusa", "Janakpur", "Major city in Dhanusa"),
                    ("Mahottari", "Jaleshwar", "Major city in Mahottari"),
                    ("Mahottari", "Bardibas", "City in Mahottari district"),
                    ("Parsa", "Birgunj", "Major city in Parsa"),
                    ("Rautahat", "Gaur", "Major city in Rautahat"),
                    ("Saptari", "Rajbiraj", "Major city in Saptari"),
                    ("Sarlahi", "Malangwa", "Major city in Sarlahi"),
                    ("Siraha", "Siraha", "Major city in Siraha"),
                    // Bagmati
                    ("Bhaktapur", "Bhaktapur", "Major city in Bhaktapur"),
                    ("Chitwan", "Bharatpur", "Major city in Chitwan"),
                    ("Dhading", "Dhadingbesi", "Major city in Dhading"),
                    ("Dolakha", "Charikot", "Major city in Dolakha"),
                    ("Kathmandu", "Kathmandu", "Capital city of Nepal"),
                    ("Kathmandu", "Kirtipur", "City in Kathmandu district"),
                    ("Kathmandu", "Tokha", "City in Kathmandu district"),
                    ("Kathmandu", "Budhanilkantha", "City in Kathmandu district"),
                    ("Kathmandu", "Gokarneshwor", "City in Kathmandu district"),
                    ("Kathmandu", "Tarakeshwar", "City in Kathmandu district"),
                    ("Kathmandu", "Chandragiri", "City in Kathmandu district"),
                    ("Kathmandu", "Nagarjun", "City in Kathmandu district"),
                    ("Kathmandu", "Kageshwori Manohara", "City in Kathmandu district"),
                    ("Kathmandu", "Dakshinkali", "City in Kathmandu district"),
                    ("Kathmandu", "Shankharapur", "City in Kathmandu district"),
                    ("Kavrepalanchok", "Dhulikhel", "Major city in Kavrepalanchok"),
                    ("Kavrepalanchok", "Banepa", "City in Kavrepalanchok district"),
                    ("Kavrepalanchok", "Panauti", "City in Kavrepalanchok district"),
                    ("Lalitpur", "Patan", "Major city in Lalitpur"),
                    ("Lalitpur", "Godawari", "City in Lalitpur district"),
                    ("Lalitpur", "Mahalaxmi", "City in Lalitpur district"),
                    ("Lalitpur", "Konjyosom", "City in Lalitpur district"),
                    ("Makwanpur", "Hetauda", "Major city in Makwanpur"),
                    ("Nuwakot", "Bidur", "Major city in Nuwakot"),
                    ("Ramechhap", "Manthali", "Major city in Ramechhap"),
                    ("Rasuwa", "Dhunche", "Major city in Rasuwa"),
                    ("Sindhuli", "Sindhulimadhi", "Major city in Sindhuli"),
                    ("Sindhupalchok", "Chautara", "Major city in Sindhupalchok"),
                    // Gandaki
                    ("Baglung", "Baglung", "Major city in Baglung"),
                    ("Baglung", "Kusma", "City in Baglung district"),
                    ("Gorkha", "Gorkha", "Major city in Gorkha"),
                    ("Kaski", "Pokhara", "Major city in Kaski"),
                    ("Lamjung", "Besisahar", "Major city in Lamjung"),
                    ("Manang", "Chame", "Major city in Manang"),
                    ("Mustang", "Jomsom", "Major city in Mustang"),
                    ("Myagdi", "Beni", "Major city in Myagdi"),
                    ("Nawalpur", "Kawasoti", "Major city in Nawalpur"),
                    ("Parbat", "Kusma", "Major city in Parbat"),
                    ("Syangja", "Putalibazar", "Major city in Syangja"),
                    ("Tanahun", "Damauli", "Major city in Tanahun"),
                    // Lumbini
                    ("Arghakhanchi", "Sandhikharka", "Major city in Arghakhanchi"),
                    ("Banke", "Nepalgunj", "Major city in Banke"),
                    ("Bardiya", "Gulariya", "Major city in Bardiya"),
                    ("Dang", "Ghorahi", "Major city in Dang"),
                    ("Dang", "Tulsipur", "City in Dang district"),
                    ("Eastern Rukum", "Rukumkot", "Major city in Eastern Rukum"),
                    ("Gulmi", "Tamghas", "Major city in Gulmi"),
                    ("Kapilvastu", "Taulihawa", "Major city in Kapilvastu"),
                    ("Parasi", "Ramgram", "Major city in Parasi"),
                    ("Palpa", "Tansen", "Major city in Palpa"),
                    ("Pyuthan", "Pyuthan", "Major city in Pyuthan"),
                    ("Rolpa", "Liwang", "Major city in Rolpa"),
                    ("Rupandehi", "Butwal", "Major city in Rupandehi"),
                    ("Rupandehi", "Siddharthanagar", "City in Rupandehi district"),
                    // Karnali
                    ("Dailekh", "Dailekh", "Major city in Dailekh"),
                    ("Dolpa", "Dunai", "Major city in Dolpa"),
                    ("Humla", "Simikot", "Major city in Humla"),
                    ("Jajarkot", "Khalanga", "Major city in Jajarkot"),
                    ("Jumla", "Jumla", "Major city in Jumla"),
                    ("Kalikot", "Manma", "Major city in Kalikot"),
                    ("Mugu", "Gamgadhi", "Major city in Mugu"),
                    ("Salyan", "Khalanga", "Major city in Salyan"),
                    ("Surkhet", "Birendranagar", "Major city in Surkhet"),
                    ("Western Rukum", "Musikot", "Major city in Western Rukum"),
                    // Sudurpashchim
                    ("Achham", "Mangalsen", "Major city in Achham"),
                    ("Baitadi", "Dasharathchand", "Major city in Baitadi"),
                    ("Bajhang", "Chainpur", "Major city in Bajhang"),
                    ("Bajura", "Martadi", "Major city in Bajura"),
                    ("Dadeldhura", "Amargadhi", "Major city in Dadeldhura"),
                    ("Darchula", "Darchula", "Major city in Darchula"),
                    ("Doti", "Dipayal Silgadhi", "Major city in Doti"),
                    ("Kailali", "Dhangadhi", "Major city in Kailali"),
                    ("Kailali", "Tikapur", "City in Kailali district"),
                    ("Kanchanpur", "Mahendranagar", "Major city in Kanchanpur")
                };

                var nepalProvisions = new List<StaticData>();
                nepalProvisions.AddRange(provinces);
                nepalProvisions.AddRange(districts.Select(d => new StaticData
                {
                    Key = d.Province,
                    Value = d.District,
                    Description = d.Description,
                    Sts = "Active"
                }));
                nepalProvisions.AddRange(cities.Select(c => new StaticData
                {
                    Key = c.District,
                    Value = c.City,
                    Description = c.Description,
                    Sts = "Active"
                }));

                // Insert into database if not already present
                foreach (var provision in nepalProvisions)
                {
                    if (!context.StaticData.Any(sd => sd.Key == provision.Key && sd.Value == provision.Value))
                    {
                        await context.StaticData.AddAsync(provision);
                        _logger.LogInformation($"Inserted Nepal Provision: {provision.Key} - {provision.Value}");
                    }
                }
                //insert district and city data
                foreach (var district in districts)
                {
                    if (!context.StaticData.Any(sd => sd.Key == district.Province && sd.Value == district.District))
                    {
                        var districtData = new StaticData
                        {
                            Key = district.Province,
                            Value = district.District,
                            Description = district.Description,
                            Sts = "Active"
                        };
                        await context.StaticData.AddAsync(districtData);
                        _logger.LogInformation($"Inserted District: {district.District}");
                    }
                }
                foreach (var city in cities)
                {
                    if (!context.StaticData.Any(sd => sd.Key == city.District && sd.Value == city.City))
                    {
                        var cityData = new StaticData
                        {
                            Key = city.District,
                            Value = city.City,
                            Description = city.Description,
                            Sts = "Active"
                        };
                        await context.StaticData.AddAsync(cityData);
                        _logger.LogInformation($"Inserted City: {city.City}");
                    }
                }


                var userTypeValues = new List<string> { "Admin", "Client", "Public" };
                foreach (var userType in userTypeValues)
                {
                    if (!context.StaticData.Any(sd => sd.Key == "UserType" && sd.Value == userType))
                    {
                        var userTypeData = new StaticData
                        {
                            Key = "UserType",
                            Value = userType,
                            Description = $"Represents {userType} user type",
                            Sts = "Active"
                        };

                        await context.StaticData.AddAsync(userTypeData);
                        _logger.LogInformation($"Inserted UserType: {userType}");
                    }
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Static data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during static data seeding: {ex.Message}");
            }
        }
    }
}