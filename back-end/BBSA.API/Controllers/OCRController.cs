using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BBSA.API.Controllers
{
    [Route("api/ocr")]
    [ApiController]
    public class OCRController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public Task TestAsync()
        {
            string ocrResultJson = @"
            {
                ""language"": ""en"",
                ""textAngle"": 0.0,
                ""orientation"": ""Up"",
                ""regions"": [
                    {
                        ""boundingBox"": ""220,830,877,380"",
                        ""lines"": [
                            {
                                ""boundingBox"": ""480,830,617,32"",
                                ""words"": [
                                    {
                                        ""boundingBox"": ""480,833,111,29"",
                                        ""text"": ""Belgium""
                                    },
                                    {
                                        ""boundingBox"": ""602,831,95,24"",
                                        ""text"": ""Billiard""
                                    },
                                    {
                                        ""boundingBox"": ""708,832,22,23"",
                                        ""text"": ""&""
                                    },
                                    {
                                        ""boundingBox"": ""739,830,114,25"",
                                        ""text"": ""Snooker""
                                    },
                                    {
                                        ""boundingBox"": ""862,830,159,23"",
                                        ""text"": ""Association""
                                    },
                                    {
                                        ""boundingBox"": ""1032,830,65,23"",
                                        ""text"": ""VZW""
                                    }
                                ]
                            },
                            {
                                ""boundingBox"": ""501,870,573,28"",
                                ""words"": [
                                    {
                                        ""boundingBox"": ""501,870,188,28"",
                                        ""text"": ""Acknowledged""
                                    },
                                    {
                                        ""boundingBox"": ""700,871,37,27"",
                                        ""text"": ""by:""
                                    },
                                    {
                                        ""boundingBox"": ""747,871,61,21"",
                                        ""text"": ""BOIC""
                                    },
                                    {
                                        ""boundingBox"": ""815,879,16,4"",
                                        ""text"": ""-""
                                    },
                                    {
                                        ""boundingBox"": ""840,870,63,20"",
                                        ""text"": ""EBSA""
                                    },
                                    {
                                        ""boundingBox"": ""911,879,16,4"",
                                        ""text"": ""-""
                                    },
                                    {
                                        ""boundingBox"": ""936,870,51,21"",
                                        ""text"": ""IBSF""
                                    },
                                    {
                                        ""boundingBox"": ""996,881,9,4"",
                                        ""text"": ""-""
                                    },
                                    {
                                        ""boundingBox"": ""1013,870,61,21"",
                                        ""text"": ""WSA""
                                    }
                                ]
                            },
                            {
                                ""boundingBox"": ""417,906,679,30"",
                                ""words"": [
                                {
                                    ""boundingBox"": ""417,911,121,25"",
                                    ""text"": ""Secretary""
                                },
                                {
                                    ""boundingBox"": ""546,909,108,22"",
                                    ""text"": ""General:""
                                },
                                {
                                    ""boundingBox"": ""665,906,193,24"",
                                    ""text"": ""Kouterveldlaan""
                                },
                                {
                                    ""boundingBox"": ""868,907,30,20"",
                                    ""text"": ""20""
                                },
                                {
                                    ""boundingBox"": ""905,916,17,4"",
                                    ""text"": ""—""
                                },
                                {
                                    ""boundingBox"": ""930,907,61,21"",
                                    ""text"": ""9550""
                                },
                                {
                                    ""boundingBox"": ""1001,906,95,22"",
                                    ""text"": ""Herzele""
                                }
                                ]
                            },
                            {
                                ""boundingBox"": ""551,986,125,23"",
                                ""words"": [
                                {
                                    ""boundingBox"": ""551,986,125,23"",
                                    ""text"": ""REGIONS""
                                }
                                ]
                            },
                            {
                                ""boundingBox"": ""220,1017,787,33"",
                                ""words"": [
                                {
                                    ""boundingBox"": ""220,1027,177,22"",
                                    ""text"": ""ANTWERPEN""
                                },
                                {
                                    ""boundingBox"": ""408,1039,9,3"",
                                    ""text"": ""-""
                                },
                                {
                                    ""boundingBox"": ""428,1028,131,22"",
                                    ""text"": ""BRABANT""
                                },
                                {
                                    ""boundingBox"": ""567,1039,9,4"",
                                    ""text"": ""-""
                                },
                                {
                                    ""boundingBox"": ""587,1026,126,24"",
                                    ""text"": ""HAINAUT""
                                },
                                {
                                    ""boundingBox"": ""722,1037,9,3"",
                                    ""text"": ""-""
                                },
                                {
                                    ""boundingBox"": ""742,1023,127,24"",
                                    ""text"": ""LIMBURG""
                                },
                                {
                                    ""boundingBox"": ""879,1034,18,3"",
                                    ""text"": ""-""
                                },
                                {
                                    ""boundingBox"": ""906,1017,74,28"",
                                    ""text"": ""LIEGE""
                                },
                                {
                                    ""boundingBox"": ""989,1034,18,3"",
                                    ""text"": ""-""
                                }
                                ]
                            },
                            {
                                ""boundingBox"": ""322,1064,579,27"",
                                ""words"": [
                                {
                                    ""boundingBox"": ""322,1067,274,24"",
                                    ""text"": ""OOST-VLAANDEREN""
                                },
                                {
                                    ""boundingBox"": ""608,1080,8,3"",
                                    ""text"": ""-""
                                },
                                {
                                    ""boundingBox"": ""626,1064,275,26"",
                                    ""text"": ""WEST-VLAANDEREN""
                                }
                                ]
                            },
                            {
                                ""boundingBox"": ""366,1113,491,40"",
                                ""words"": [
                                {
                                    ""boundingBox"": ""366,1115,332,38"",
                                    ""text"": ""COMPETITION""
                                },
                                {
                                    ""boundingBox"": ""718,1113,139,37"",
                                    ""text"": ""FORM""
                                }
                                ]
                            },
                            {
                                ""boundingBox"": ""291,1178,642,32"",
                                ""words"": [
                                {
                                    ""boundingBox"": ""291,1180,87,30"",
                                    ""text"": ""GIVE""
                                },
                                {
                                    ""boundingBox"": ""393,1181,81,29"",
                                    ""text"": ""FAIR""
                                },
                                {
                                    ""boundingBox"": ""489,1180,90,29"",
                                    ""text"": ""PLAY""
                                },
                                {
                                    ""boundingBox"": ""592,1180,83,29"",
                                    ""text"": ""AND""
                                },
                                {
                                    ""boundingBox"": ""689,1178,72,31"",
                                    ""text"": ""GET""
                                },
                                {
                                    ""boundingBox"": ""774,1178,159,30"",
                                    ""text"": ""RESPECT""
                                }
                                ]
                            }
                        ]
                    },
                    {
                        ""boundingBox"": ""1237,907,335,251"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1237,907,99,20"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1237,907,99,20"",
                                ""text"": ""Division""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1312,937,260,67"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1312,954,77,49"",
                                ""text"": ""27""
                            },
                            {
                                ""boundingBox"": ""1432,937,69,67"",
                                ""text"": ""z/""
                            },
                            {
                                ""boundingBox"": ""1504,953,68,47"",
                                ""text"": ""zo""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1344,1020,151,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1344,1020,81,22"",
                                ""text"": ""Match""
                            },
                            {
                                ""boundingBox"": ""1436,1021,59,20"",
                                ""text"": ""Date""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1321,1135,198,23"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1321,1135,106,23"",
                                ""text"": ""Snooker""
                            },
                            {
                                ""boundingBox"": ""1435,1135,84,22"",
                                ""text"": ""Tables""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1574,903,73,21"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1574,903,73,21"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1574,903,73,21"",
                                ""text"": ""Week""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""120,1298,462,237"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""124,1298,149,20"",
                            ""words"": [
                            {
                                ""boundingBox"": ""124,1298,74,20"",
                                ""text"": ""Home""
                            },
                            {
                                ""boundingBox"": ""206,1299,67,19"",
                                ""text"": ""team""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""122,1402,460,56"",
                            ""words"": [
                            {
                                ""boundingBox"": ""122,1413,79,27"",
                                ""text"": ""Player""
                            },
                            {
                                ""boundingBox"": ""212,1402,30,33"",
                                ""text"": ""I:""
                            },
                            {
                                ""boundingBox"": ""505,1414,77,44"",
                                ""text"": ""ROA""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""120,1496,121,39"",
                            ""words"": [
                            {
                                ""boundingBox"": ""120,1508,80,27"",
                                ""text"": ""Player""
                            },
                            {
                                ""boundingBox"": ""210,1496,31,34"",
                                ""text"": ""2:""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""922,1296,97,21"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""922,1296,97,21"",
                            ""words"": [
                            {
                                ""boundingBox"": ""922,1296,97,21"",
                                ""text"": ""Visitors""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""735,1321,618,43"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""735,1321,618,43"",
                            ""words"": [
                            {
                                ""boundingBox"": ""735,1321,123,43"",
                                ""text"": ""5020""
                            },
                            {
                                ""boundingBox"": ""1316,1326,37,37"",
                                ""text"": ""6""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1097,1252,268,286"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1133,1252,232,28"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1133,1254,61,21"",
                                ""text"": ""Start""
                            },
                            {
                                ""boundingBox"": ""1203,1252,162,28"",
                                ""text"": ""Competition""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1097,1490,172,48"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1097,1490,172,48"",
                                ""text"": ""gheuemvs""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1453,1191,252,256"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1566,1191,50,19"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1566,1191,50,19"",
                                ""text"": ""00""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1453,1249,252,28"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1453,1250,45,22"",
                                ""text"": ""End""
                            },
                            {
                                ""boundingBox"": ""1508,1251,26,21"",
                                ""text"": ""of""
                            },
                            {
                                ""boundingBox"": ""1543,1249,162,28"",
                                ""text"": ""Competition""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1526,1316,117,40"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1526,1316,117,40"",
                                ""text"": ""5073""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1572,1396,80,51"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1572,1396,80,51"",
                                ""text"": ""7704""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""671,1515,40,111"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""672,1515,39,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""672,1515,39,15"",
                                ""text"": ""no:""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""671,1610,40,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""671,1610,40,16"",
                                ""text"": ""no:""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""774,1401,270,241"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""924,1401,120,39"",
                            ""words"": [
                            {
                                ""boundingBox"": ""924,1413,79,27"",
                                ""text"": ""Player""
                            },
                            {
                                ""boundingBox"": ""1012,1401,32,34"",
                                ""text"": ""4:""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""924,1497,120,39"",
                            ""words"": [
                            {
                                ""boundingBox"": ""924,1508,80,28"",
                                ""text"": ""Player""
                            },
                            {
                                ""boundingBox"": ""1013,1497,31,34"",
                                ""text"": ""5:""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""774,1508,100,52"",
                            ""words"": [
                            {
                                ""boundingBox"": ""774,1508,100,52"",
                                ""text"": ""sol/""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""785,1592,259,50"",
                            ""words"": [
                            {
                                ""boundingBox"": ""785,1599,96,43"",
                                ""text"": ""504""
                            },
                            {
                                ""boundingBox"": ""924,1604,80,27"",
                                ""text"": ""Player""
                            },
                            {
                                ""boundingBox"": ""1013,1592,31,34"",
                                ""text"": ""6:""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1100,1582,113,52"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1100,1582,113,52"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1100,1592,41,36"",
                                ""text"": ""G""
                            },
                            {
                                ""boundingBox"": ""1147,1582,66,52"",
                                ""text"": ""0B""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1297,1683,106,24"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1297,1683,106,24"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1297,1683,106,24"",
                                ""text"": ""POINTS""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1477,1512,100,193"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1477,1512,40,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1477,1512,40,15"",
                                ""text"": ""no:""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1478,1607,39,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1478,1607,39,16"",
                                ""text"": ""no:""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1483,1682,94,23"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1483,1682,94,23"",
                                ""text"": ""BREAK""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""110,1688,46,657"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""118,1688,38,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""118,1688,38,15"",
                                ""text"": ""no.""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""118,1734,18,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""118,1734,18,29"",
                                ""text"": ""1""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""116,1805,20,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""116,1805,20,29"",
                                ""text"": ""2""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""115,1877,20,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""115,1877,20,29"",
                                ""text"": ""3""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""114,1951,20,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""114,1951,20,30"",
                                ""text"": ""2""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""113,2023,20,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""113,2023,20,30"",
                                ""text"": ""3""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""114,2095,18,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""114,2095,18,30"",
                                ""text"": ""1""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""111,2170,20,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""111,2170,20,30"",
                                ""text"": ""3""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""112,2243,18,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""112,2243,18,30"",
                                ""text"": ""1""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""110,2315,19,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""110,2315,19,30"",
                                ""text"": ""2""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""221,1685,112,683"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""221,1685,105,23"",
                            ""words"": [
                            {
                                ""boundingBox"": ""221,1685,105,23"",
                                ""text"": ""POINTS""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""264,1947,69,52"",
                            ""words"": [
                            {
                                ""boundingBox"": ""264,1947,69,52"",
                                ""text"": ""23""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""254,2323,44,45"",
                            ""words"": [
                            {
                                ""boundingBox"": ""254,2323,44,45"",
                                ""text"": ""5""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""405,1685,246,168"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""405,1685,246,23"",
                            ""words"": [
                            {
                                ""boundingBox"": ""405,1685,92,22"",
                                ""text"": ""BREAK""
                            },
                            {
                                ""boundingBox"": ""547,1685,104,23"",
                                ""text"": ""POINTS""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""589,1739,50,42"",
                            ""words"": [
                            {
                                ""boundingBox"": ""589,1739,50,42"",
                                ""text"": ""58""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""584,1810,55,43"",
                            ""words"": [
                            {
                                ""boundingBox"": ""584,1810,55,43"",
                                ""text"": ""53""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""729,1680,498,28"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""729,1680,347,28"",
                            ""words"": [
                            {
                                ""boundingBox"": ""729,1685,93,22"",
                                ""text"": ""BREAK""
                            },
                            {
                                ""boundingBox"": ""869,1680,66,17"",
                                ""text"": ""frames""
                            },
                            {
                                ""boundingBox"": ""972,1685,104,23"",
                                ""text"": ""POINTS""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1134,1685,93,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1134,1685,93,22"",
                                ""text"": ""BREAK""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""874,1728,62,594"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""874,1728,62,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,1728,62,15"",
                                ""text"": ""FI-FIO""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,1798,62,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,1798,62,15"",
                                ""text"": ""F2-F11""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,1869,62,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,1869,62,16"",
                                ""text"": ""F3-F12""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,1944,62,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,1944,62,15"",
                                ""text"": ""F4-F13""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,2015,62,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,2015,62,15"",
                                ""text"": ""F5-F14""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,2086,61,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,2086,61,16"",
                                ""text"": ""F6-F15""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,2161,62,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,2161,62,16"",
                                ""text"": ""F7-F16""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,2233,62,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,2233,62,16"",
                                ""text"": ""F8-F17""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""874,2306,62,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""874,2306,62,16"",
                                ""text"": ""F9-F18""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1003,1813,69,472"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1010,1813,58,34"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1010,1813,58,34"",
                                ""text"": ""55""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1003,1964,69,41"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1003,1964,69,41"",
                                ""text"": ""50""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1041,2028,31,46"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1041,2028,31,46"",
                                ""text"": ""4""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1017,2249,42,36"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1017,2249,42,36"",
                                ""text"": ""5""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""106,2425,253,226"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""108,2425,179,21"",
                            ""words"": [
                            {
                                ""boundingBox"": ""108,2425,179,21"",
                                ""text"": ""Comments:....""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""106,2623,253,28"",
                            ""words"": [
                            {
                                ""boundingBox"": ""106,2624,95,27"",
                                ""text"": ""Captain""
                            },
                            {
                                ""boundingBox"": ""213,2623,72,23"",
                                ""text"": ""home""
                            },
                            {
                                ""boundingBox"": ""293,2626,66,20"",
                                ""text"": ""team""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""522,2490,785,122"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1245,2490,51,59"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1245,2490,51,59"",
                                ""text"": ""g""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""522,2583,785,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""522,2584,138,28"",
                                ""text"": ""Signatures""
                            },
                            {
                                ""boundingBox"": ""670,2584,72,28"",
                                ""text"": ""apply""
                            },
                            {
                                ""boundingBox"": ""749,2586,28,20"",
                                ""text"": ""to""
                            },
                            {
                                ""boundingBox"": ""786,2583,72,23"",
                                ""text"": ""\""read""
                            },
                            {
                                ""boundingBox"": ""868,2583,47,23"",
                                ""text"": ""and""
                            },
                            {
                                ""boundingBox"": ""925,2584,140,28"",
                                ""text"": ""approved\""""
                            },
                            {
                                ""boundingBox"": ""1075,2584,26,23"",
                                ""text"": ""of""
                            },
                            {
                                ""boundingBox"": ""1110,2584,29,23"",
                                ""text"": ""all""
                            },
                            {
                                ""boundingBox"": ""1149,2585,82,23"",
                                ""text"": ""stated""
                            },
                            {
                                ""boundingBox"": ""1241,2585,66,23"",
                                ""text"": ""data.""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1314,2393,269,154"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1314,2393,235,36"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1314,2409,28,7"",
                                ""text"": ""-""
                            },
                            {
                                ""boundingBox"": ""1367,2393,182,36"",
                                ""text"": ""SCORE-""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1531,2500,52,47"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1531,2500,52,47"",
                                ""text"": ""3""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""392,2788,13,22"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""392,2788,13,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""392,2788,13,22"",
                                ""text"": ""2""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""534,2790,13,22"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""534,2790,13,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""534,2790,13,22"",
                                ""text"": ""3""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1586,1508,139,1307"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1586,1508,80,47"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1586,1508,80,47"",
                                ""text"": ""703""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1594,1589,80,45"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1594,1589,47,45"",
                                ""text"": ""70""
                            },
                            {
                                ""boundingBox"": ""1646,1595,28,39"",
                                ""text"": ""H""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1677,1686,39,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1677,1686,39,15"",
                                ""text"": ""no.""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1696,1732,22,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1696,1732,22,29"",
                                ""text"": ""4""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1698,1803,20,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1698,1803,20,30"",
                                ""text"": ""6""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1699,1876,20,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1699,1876,20,29"",
                                ""text"": ""5""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1699,1951,22,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1699,1951,22,29"",
                                ""text"": ""4""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1702,2022,19,31"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1702,2022,19,31"",
                                ""text"": ""6""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1703,2095,19,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1703,2095,19,30"",
                                ""text"": ""5""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1702,2171,22,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1702,2171,22,30"",
                                ""text"": ""4""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1705,2243,20,31"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1705,2243,20,31"",
                                ""text"": ""6""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1706,2317,19,30"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1706,2317,19,30"",
                                ""text"": ""5""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1627,2793,13,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1627,2793,13,22"",
                                ""text"": ""6""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""104,2786,121,265"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""104,2786,78,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""104,2786,78,29"",
                                ""text"": ""Player""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""123,2957,101,49"",
                            ""words"": [
                            {
                                ""boundingBox"": ""123,2957,101,49"",
                                ""text"": ""OQ9""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""140,3013,65,17"",
                            ""words"": [
                            {
                                ""boundingBox"": ""140,3013,65,17"",
                                ""text"": ""TEAM""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""121,3033,104,18"",
                            ""words"": [
                            {
                                ""boundingBox"": ""121,3033,104,18"",
                                ""text"": ""BELGIUM""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""258,2788,12,21"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""258,2788,12,21"",
                            ""words"": [
                            {
                                ""boundingBox"": ""258,2788,12,21"",
                                ""text"": ""1""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""622,2794,254,208"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""659,2794,82,23"",
                            ""words"": [
                            {
                                ""boundingBox"": ""659,2794,82,23"",
                                ""text"": ""Name:""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""622,2937,254,46"",
                            ""words"": [
                            {
                                ""boundingBox"": ""622,2937,254,46"",
                                ""text"": ""aramith""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""628,2987,246,15"",
                            ""words"": [
                            {
                                ""boundingBox"": ""628,2987,11,13"",
                                ""text"": ""a""
                            },
                            {
                                ""boundingBox"": ""648,2987,54,14"",
                                ""text"": ""ILL/""
                            },
                            {
                                ""boundingBox"": ""709,2988,54,13"",
                                ""text"": ""ARD""
                            },
                            {
                                ""boundingBox"": ""787,2988,87,14"",
                                ""text"": ""BALLS""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""940,2626,449,360"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1190,2626,199,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1190,2626,97,29"",
                                ""text"": ""Captain""
                            },
                            {
                                ""boundingBox"": ""1296,2626,93,23"",
                                ""text"": ""visitors""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1192,2790,79,29"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1192,2790,79,29"",
                                ""text"": ""Player""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1360,2792,15,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1360,2792,15,22"",
                                ""text"": ""4""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1185,2921,54,16"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1185,2921,54,16"",
                                ""text"": ""Cloth""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""940,2922,306,64"",
                            ""words"": [
                            {
                                ""boundingBox"": ""940,2922,306,64"",
                                ""text"": ""Strachan""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1482,2792,13,22"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1482,2792,13,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1482,2792,13,22"",
                                ""text"": ""5""
                            }
                            ]
                        }
                        ]
                    },
                    {
                        ""boundingBox"": ""1523,2994,155,45"",
                        ""lines"": [
                        {
                            ""boundingBox"": ""1523,2994,138,22"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1523,2994,138,22"",
                                ""text"": ""WORLD""
                            }
                            ]
                        },
                        {
                            ""boundingBox"": ""1523,3018,155,21"",
                            ""words"": [
                            {
                                ""boundingBox"": ""1523,3018,155,21"",
                                ""text"": ""SNOOKE""
                            }
                            ]
                        }
                        ]
                    }
                ],
                ""modelVersion"": ""2021-04-01""
            }";

            OcrResult ocrResult = JsonConvert.DeserializeObject<OcrResult>(ocrResultJson);

            foreach (OcrRegion ocrRegion in ocrResult.Regions)
            {
                foreach (OcrLine ocrLine in ocrRegion.Lines)
                {
                    foreach (OcrWord ocrWord in ocrLine.Words)
                    {
                        if (ocrWord.Text == "POINTS")
                        {
                            Console.WriteLine("Text: " + ocrWord.Text);
                            Console.WriteLine("BoundingBox: " + ocrWord.BoundingBox);
                            string[] boundingBoxArr = ocrWord.BoundingBox.Split(",");
                            Console.WriteLine($"CSS style: 'left: {boundingBoxArr[0]}px; top: {boundingBoxArr[1]}px; width: {boundingBoxArr[2]}px; height: {boundingBoxArr[3]}px;'");
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}