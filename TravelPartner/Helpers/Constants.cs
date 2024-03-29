﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TravelPartner.Model;

namespace TravelPartner.Helpers
{
    public class Constants
    {
        public const string TIMESTAMP_KEY = "timestampkey";
        public const string EXCHANGE_RATE_URL = "http://www.apilayer.net/api/live?access_key=3423a5771f530cf0ca1c86a7981671c4&format=1";
        private const string jsonCountries = "{'AED':'United Arab Emirates Dirham','AFN':'Afghan Afghani','ALL':'Albanian Lek','AMD':'Armenian Dram','ANG':'Netherlands Antillean Guilder','AOA':'Angolan Kwanza','ARS':'Argentine Peso','AUD':'Australian Dollar','AWG':'Aruban Florin','AZN':'Azerbaijani Manat','BAM':'Bosnia-Herzegovina Convertible Mark','BBD':'Barbadian Dollar','BDT':'Bangladeshi Taka','BGN':'Bulgarian Lev','BHD':'Bahraini Dinar','BIF':'Burundian Franc','BMD':'Bermudan Dollar','BND':'Brunei Dollar','BOB':'Bolivian Boliviano','BRL':'Brazilian Real','BSD':'Bahamian Dollar','BTC':'Bitcoin','BTN':'Bhutanese Ngultrum','BWP':'Botswanan Pula','BYN':'New Belarusian Ruble','BYR':'Belarusian Ruble','BZD':'Belize Dollar','CAD':'Canadian Dollar','CDF':'Congolese Franc','CHF':'Swiss Franc','CLF':'Chilean Unit of Account (UF)','CLP':'Chilean Peso','CNY':'Chinese Yuan','COP':'Colombian Peso','CRC':'Costa Rican Colu00f3n','CUC':'Cuban Convertible Peso','CUP':'Cuban Peso','CVE':'Cape Verdean Escudo','CZK':'Czech Republic Koruna','DJF':'Djiboutian Franc','DKK':'Danish Krone','DOP':'Dominican Peso','DZD':'Algerian Dinar','EGP':'Egyptian Pound','ERN':'Eritrean Nakfa','ETB':'Ethiopian Birr','EUR':'Euro','FJD':'Fijian Dollar','FKP':'Falkland Islands Pound','GBP':'British Pound Sterling','GEL':'Georgian Lari','GGP':'Guernsey Pound','GHS':'Ghanaian Cedi','GIP':'Gibraltar Pound','GMD':'Gambian Dalasi','GNF':'Guinean Franc','GTQ':'Guatemalan Quetzal','GYD':'Guyanaese Dollar','HKD':'Hong Kong Dollar','HNL':'Honduran Lempira','HRK':'Croatian Kuna','HTG':'Haitian Gourde','HUF':'Hungarian Forint','IDR':'Indonesian Rupiah','ILS':'Israeli New Sheqel','IMP':'Manx pound','INR':'Indian Rupee','IQD':'Iraqi Dinar','IRR':'Iranian Rial','ISK':'Icelandic Kru00f3na','JEP':'Jersey Pound','JMD':'Jamaican Dollar','JOD':'Jordanian Dinar','JPY':'Japanese Yen','KES':'Kenyan Shilling','KGS':'Kyrgystani Som','KHR':'Cambodian Riel','KMF':'Comorian Franc','KPW':'North Korean Won','KRW':'South Korean Won','KWD':'Kuwaiti Dinar','KYD':'Cayman Islands Dollar','KZT':'Kazakhstani Tenge','LAK':'Laotian Kip','LBP':'Lebanese Pound','LKR':'Sri Lankan Rupee','LRD':'Liberian Dollar','LSL':'Lesotho Loti','LTL':'Lithuanian Litas','LVL':'Latvian Lats','LYD':'Libyan Dinar','MAD':'Moroccan Dirham','MDL':'Moldovan Leu','MGA':'Malagasy Ariary','MKD':'Macedonian Denar','MMK':'Myanma Kyat','MNT':'Mongolian Tugrik','MOP':'Macanese Pataca','MRO':'Mauritanian Ouguiya','MUR':'Mauritian Rupee','MVR':'Maldivian Rufiyaa','MWK':'Malawian Kwacha','MXN':'Mexican Peso','MYR':'Malaysian Ringgit','MZN':'Mozambican Metical','NAD':'Namibian Dollar','NGN':'Nigerian Naira','NIO':'Nicaraguan Cu00f3rdoba','NOK':'Norwegian Krone','NPR':'Nepalese Rupee','NZD':'New Zealand Dollar','OMR':'Omani Rial','PAB':'Panamanian Balboa','PEN':'Peruvian Nuevo Sol','PGK':'Papua New Guinean Kina','PHP':'Philippine Peso','PKR':'Pakistani Rupee','PLN':'Polish Zloty','PYG':'Paraguayan Guarani','QAR':'Qatari Rial','RON':'Romanian Leu','RSD':'Serbian Dinar','RUB':'Russian Ruble','RWF':'Rwandan Franc','SAR':'Saudi Riyal','SBD':'Solomon Islands Dollar','SCR':'Seychellois Rupee','SDG':'Sudanese Pound','SEK':'Swedish Krona','SGD':'Singapore Dollar','SHP':'Saint Helena Pound','SLL':'Sierra Leonean Leone','SOS':'Somali Shilling','SRD':'Surinamese Dollar','STD':'Su00e3o Tomu00e9 and Pru00edncipe Dobra','SVC':'Salvadoran Colu00f3n','SYP':'Syrian Pound','SZL':'Swazi Lilangeni','THB':'Thai Baht','TJS':'Tajikistani Somoni','TMT':'Turkmenistani Manat','TND':'Tunisian Dinar','TOP':'Tongan Pau02bbanga','TRY':'Turkish Lira','TTD':'Trinidad and Tobago Dollar','TWD':'New Taiwan Dollar','TZS':'Tanzanian Shilling','UAH':'Ukrainian Hryvnia','UGX':'Ugandan Shilling','USD':'United States Dollar','UYU':'Uruguayan Peso','UZS':'Uzbekistan Som','VEF':'Venezuelan Bolu00edvar Fuerte','VND':'Vietnamese Dong','VUV':'Vanuatu Vatu','WST':'Samoan Tala','XAF':'CFA Franc BEAC','XAG':'Silver (troy ounce)','XAU':'Gold (troy ounce)','XCD':'East Caribbean Dollar','XDR':'Special Drawing Rights','XOF':'CFA Franc BCEAO','XPF':'CFP Franc','YER':'Yemeni Rial','ZAR':'South African Rand','ZMK':'Zambian Kwacha (pre-2013)','ZMW':'Zambian Kwacha','ZWL':'Zimbabwean Dollar'}";
        private static List<ChoosenCurrenciesTable> choosenCurrencies = new List<ChoosenCurrenciesTable>()
        {
            new ChoosenCurrenciesTable(){CurrencyId = 1},
            new ChoosenCurrenciesTable(){CurrencyId = 2},
            new ChoosenCurrenciesTable(){CurrencyId = 3},
            new ChoosenCurrenciesTable(){CurrencyId = 4},
            new ChoosenCurrenciesTable(){CurrencyId = 5},
            new ChoosenCurrenciesTable(){CurrencyId = 6},
            new ChoosenCurrenciesTable(){CurrencyId = 7},
            new ChoosenCurrenciesTable(){CurrencyId = 8},
            new ChoosenCurrenciesTable(){CurrencyId = 9},
            new ChoosenCurrenciesTable(){CurrencyId = 10}
        };

        public static List<ChoosenCurrenciesTable> ChoosenCurrencies { get => choosenCurrencies; private set => choosenCurrencies = value; }

        public static List<Currency> GetCountries()
        {
            List<Currency> countries = new List<Currency>();
            JObject obj = JsonConvert.DeserializeObject<JObject>(jsonCountries);
            foreach (var propName in obj.Children<JProperty>())
            {
                countries.Add(new Currency()
                {
                    Name = propName.Value.ToString(),
                    ShortName = propName.Name,
                    Value = Currency.NO_VALUE
                }) ;
            }
            return countries;
        } 
    }
}
