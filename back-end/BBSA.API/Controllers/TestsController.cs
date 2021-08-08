using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSA.API.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        [Route("computer-vision")]
        [Produces("text/plain")]
        public Task<string> ComputerVisionAsync()
        {
            StringBuilder responseMessage = new StringBuilder();

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
                        string[] boundingBoxArr = ocrWord.BoundingBox.Split(",");
                        if (ocrWord.Text == "POINTS")
                        {
                            responseMessage.AppendLine("Text: " + ocrWord.Text);
                            responseMessage.AppendLine("BoundingBox: " + ocrWord.BoundingBox);
                            responseMessage.AppendLine($"CSS style: 'left: {boundingBoxArr[0]}px; top: {boundingBoxArr[1]}px; width: {boundingBoxArr[2]}px; height: {boundingBoxArr[3]}px;'");
                        }

                        int[] boundingBoxIntArr = boundingBoxArr.Select(x => int.Parse(x)).ToArray();
                        int[] boundingBoxTopLeftBottomRight = new int[] {
                            boundingBoxIntArr[1],
                            boundingBoxIntArr[0],
                            boundingBoxIntArr[1] + boundingBoxIntArr[3],
                            boundingBoxIntArr[0] + boundingBoxIntArr[2]
                        };

                        int x = 610;
                        int y = 1757;
                        if (boundingBoxTopLeftBottomRight[0] < y && y < boundingBoxTopLeftBottomRight[2] &&
                            boundingBoxTopLeftBottomRight[1] < x && x < boundingBoxTopLeftBottomRight[3])
                        {
                            responseMessage.AppendLine($"x = {x}, y = {y}");
                            responseMessage.AppendLine(ocrWord.Text);
                        }
                    }
                }
            }

            return Task.FromResult(responseMessage.ToString());
        }

        [HttpGet]
        [Route("form-recognizer")]
        [Produces("text/plain")]
        public Task<string> FormRecognizerAsync()
        {
            StringBuilder responseMessage = new StringBuilder();

            string resultJson = @"{
                ""status"": ""succeeded"",
                ""createdDateTime"": ""2021-08-08T19:40:47Z"",
                ""lastUpdatedDateTime"": ""2021-08-08T19:40:49Z"",
                ""analyzeResult"": {
                    ""version"": ""2.1.0"",
                    ""readResults"": [
                        {
                                ""page"": 1,
                            ""angle"": 0,
                            ""width"": 1824,
                            ""height"": 4000,
                            ""unit"": ""pixel"",
                            ""lines"": [
                                {
                                    ""boundingBox"": [
                                        260,
                                        817,
                                        431,
                                        816,
                                        431,
                                        885,
                                        262,
                                        885
                                    ],
                                    ""text"": ""BBSA"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                260,
                                                816,
                                                423,
                                                816,
                                                423,
                                                885,
                                                260,
                                                885
                                            ],
                                            ""text"": ""BBSA"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        478,
                                        830,
                                        1099,
                                        825,
                                        1099,
                                        857,
                                        478,
                                        863
                                    ],
                                    ""text"": ""Belgium Billiard & Snooker Association VZW"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                479,
                                                830,
                                                581,
                                                829,
                                                581,
                                                863,
                                                478,
                                                864
                                            ],
                                            ""text"": ""Belgium"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                595,
                                                829,
                                                697,
                                                828,
                                                696,
                                                861,
                                                595,
                                                863
                                            ],
                                            ""text"": ""Billiard"",
                                            ""confidence"": 0.995
                                        },
                                        {
                                        ""boundingBox"": [
                                                703,
                                                828,
                                                722,
                                                828,
                                                722,
                                                861,
                                                703,
                                                861
                                            ],
                                            ""text"": ""&"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                734,
                                                828,
                                                851,
                                                827,
                                                851,
                                                860,
                                                734,
                                                861
                                            ],
                                            ""text"": ""Snooker"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                857,
                                                827,
                                                1021,
                                                826,
                                                1021,
                                                858,
                                                857,
                                                860
                                            ],
                                            ""text"": ""Association"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                1027,
                                                826,
                                                1084,
                                                826,
                                                1084,
                                                857,
                                                1027,
                                                858
                                            ],
                                            ""text"": ""VZW"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1238,
                                        834,
                                        1334,
                                        834,
                                        1334,
                                        886,
                                        1238,
                                        888
                                    ],
                                    ""text"": ""4 de"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1238,
                                                834,
                                                1265,
                                                834,
                                                1266,
                                                888,
                                                1238,
                                                888
                                            ],
                                            ""text"": ""4"",
                                            ""confidence"": 0.995
                                        },
                                        {
                                        ""boundingBox"": [
                                                1276,
                                                834,
                                                1331,
                                                834,
                                                1332,
                                                887,
                                                1277,
                                                888
                                            ],
                                            ""text"": ""de"",
                                            ""confidence"": 0.931
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1560,
                                        834,
                                        1664,
                                        835,
                                        1662,
                                        885,
                                        1560,
                                        884
                                    ],
                                    ""text"": ""25"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1562,
                                                834,
                                                1638,
                                                835,
                                                1638,
                                                885,
                                                1562,
                                                884
                                            ],
                                            ""text"": ""25"",
                                            ""confidence"": 0.949
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        498,
                                        867,
                                        1077,
                                        864,
                                        1077,
                                        894,
                                        498,
                                        899
                                    ],
                                    ""text"": ""Acknowledged by: BOIC - EBSA - IBSF - WSA"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                500,
                                                870,
                                                689,
                                                866,
                                                687,
                                                899,
                                                498,
                                                899
                                            ],
                                            ""text"": ""Acknowledged"",
                                            ""confidence"": 0.986
                                        },
                                        {
                                        ""boundingBox"": [
                                                695,
                                                866,
                                                735,
                                                866,
                                                734,
                                                898,
                                                694,
                                                899
                                            ],
                                            ""text"": ""by:"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                741,
                                                866,
                                                808,
                                                865,
                                                807,
                                                898,
                                                740,
                                                898
                                            ],
                                            ""text"": ""BOIC"",
                                            ""confidence"": 0.986
                                        },
                                        {
                                        ""boundingBox"": [
                                                814,
                                                865,
                                                829,
                                                865,
                                                828,
                                                898,
                                                813,
                                                898
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                835,
                                                865,
                                                902,
                                                865,
                                                901,
                                                897,
                                                834,
                                                897
                                            ],
                                            ""text"": ""EBSA"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                910,
                                                865,
                                                923,
                                                865,
                                                922,
                                                896,
                                                909,
                                                897
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                929,
                                                865,
                                                986,
                                                865,
                                                986,
                                                896,
                                                928,
                                                896
                                            ],
                                            ""text"": ""IBSF"",
                                            ""confidence"": 0.99
                                        },
                                        {
                                        ""boundingBox"": [
                                                992,
                                                865,
                                                1004,
                                                865,
                                                1003,
                                                895,
                                                991,
                                                895
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                1010,
                                                865,
                                                1072,
                                                866,
                                                1071,
                                                894,
                                                1009,
                                                895
                                            ],
                                            ""text"": ""WSA"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        240,
                                        888,
                                        440,
                                        889,
                                        440,
                                        905,
                                        240,
                                        904
                                    ],
                                    ""text"": ""llelqium Billards & Snooker Association"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                242,
                                                889,
                                                282,
                                                889,
                                                282,
                                                904,
                                                241,
                                                904
                                            ],
                                            ""text"": ""llelqium"",
                                            ""confidence"": 0.089
                                        },
                                        {
                                        ""boundingBox"": [
                                                286,
                                                889,
                                                323,
                                                889,
                                                322,
                                                905,
                                                285,
                                                904
                                            ],
                                            ""text"": ""Billards"",
                                            ""confidence"": 0.329
                                        },
                                        {
                                        ""boundingBox"": [
                                                326,
                                                889,
                                                334,
                                                889,
                                                333,
                                                905,
                                                325,
                                                905
                                            ],
                                            ""text"": ""&"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                337,
                                                889,
                                                377,
                                                889,
                                                376,
                                                905,
                                                336,
                                                905
                                            ],
                                            ""text"": ""Snooker"",
                                            ""confidence"": 0.22
                                        },
                                        {
                                        ""boundingBox"": [
                                                380,
                                                889,
                                                439,
                                                889,
                                                438,
                                                906,
                                                379,
                                                905
                                            ],
                                            ""text"": ""Association"",
                                            ""confidence"": 0.733
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        414,
                                        906,
                                        1099,
                                        902,
                                        1099,
                                        931,
                                        414,
                                        937
                                    ],
                                    ""text"": ""Secretary General: Kouterveldlaan 20 - 9550 Herzele"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                416,
                                                909,
                                                534,
                                                907,
                                                534,
                                                936,
                                                416,
                                                937
                                            ],
                                            ""text"": ""Secretary"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                540,
                                                907,
                                                653,
                                                905,
                                                652,
                                                936,
                                                540,
                                                936
                                            ],
                                            ""text"": ""General:"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                658,
                                                905,
                                                857,
                                                903,
                                                857,
                                                934,
                                                658,
                                                936
                                            ],
                                            ""text"": ""Kouterveldlaan"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                863,
                                                903,
                                                896,
                                                903,
                                                896,
                                                934,
                                                863,
                                                934
                                            ],
                                            ""text"": ""20"",
                                            ""confidence"": 0.999
                                        },
                                        {
                                        ""boundingBox"": [
                                                904,
                                                903,
                                                920,
                                                903,
                                                920,
                                                933,
                                                904,
                                                934
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                926,
                                                903,
                                                989,
                                                903,
                                                989,
                                                933,
                                                926,
                                                933
                                            ],
                                            ""text"": ""9550"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                995,
                                                903,
                                                1098,
                                                903,
                                                1098,
                                                932,
                                                994,
                                                933
                                            ],
                                            ""text"": ""Herzele"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1237,
                                        903,
                                        1338,
                                        903,
                                        1338,
                                        931,
                                        1236,
                                        930
                                    ],
                                    ""text"": ""Division"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1238,
                                                904,
                                                1336,
                                                904,
                                                1335,
                                                932,
                                                1237,
                                                931
                                            ],
                                            ""text"": ""Division"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1572,
                                        898,
                                        1650,
                                        899,
                                        1650,
                                        926,
                                        1571,
                                        925
                                    ],
                                    ""text"": ""Week"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1571,
                                                898,
                                                1646,
                                                899,
                                                1645,
                                                926,
                                                1571,
                                                925
                                            ],
                                            ""text"": ""Week"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1311,
                                        948,
                                        1574,
                                        945,
                                        1575,
                                        1002,
                                        1311,
                                        1006
                                    ],
                                    ""text"": ""27/ 2120"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1314,
                                                950,
                                                1417,
                                                946,
                                                1418,
                                                1006,
                                                1315,
                                                1006
                                            ],
                                            ""text"": ""27/"",
                                            ""confidence"": 0.449
                                        },
                                        {
                                        ""boundingBox"": [
                                                1428,
                                                946,
                                                1567,
                                                945,
                                                1567,
                                                1002,
                                                1429,
                                                1005
                                            ],
                                            ""text"": ""2120"",
                                            ""confidence"": 0.566
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        548,
                                        984,
                                        680,
                                        983,
                                        680,
                                        1011,
                                        548,
                                        1013
                                    ],
                                    ""text"": ""REGIONS"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                548,
                                                984,
                                                676,
                                                984,
                                                675,
                                                1011,
                                                549,
                                                1014
                                            ],
                                            ""text"": ""REGIONS"",
                                            ""confidence"": 0.988
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        218,
                                        1020,
                                        1005,
                                        1015,
                                        1005,
                                        1050,
                                        218,
                                        1053
                                    ],
                                    ""text"": ""ANTWERPEN - BRABANT - HAINAUT - LIMBURG - LIÈGE -"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                220,
                                                1023,
                                                392,
                                                1023,
                                                391,
                                                1053,
                                                219,
                                                1053
                                            ],
                                            ""text"": ""ANTWERPEN"",
                                            ""confidence"": 0.993
                                        },
                                        {
                                        ""boundingBox"": [
                                                405,
                                                1023,
                                                415,
                                                1023,
                                                414,
                                                1053,
                                                404,
                                                1053
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                421,
                                                1023,
                                                556,
                                                1022,
                                                555,
                                                1052,
                                                420,
                                                1053
                                            ],
                                            ""text"": ""BRABANT"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                562,
                                                1022,
                                                574,
                                                1022,
                                                573,
                                                1052,
                                                561,
                                                1052
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                580,
                                                1022,
                                                712,
                                                1021,
                                                711,
                                                1052,
                                                579,
                                                1052
                                            ],
                                            ""text"": ""HAINAUT"",
                                            ""confidence"": 0.995
                                        },
                                        {
                                        ""boundingBox"": [
                                                718,
                                                1021,
                                                730,
                                                1020,
                                                729,
                                                1052,
                                                717,
                                                1052
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                736,
                                                1020,
                                                867,
                                                1018,
                                                866,
                                                1051,
                                                735,
                                                1052
                                            ],
                                            ""text"": ""LIMBURG"",
                                            ""confidence"": 0.995
                                        },
                                        {
                                        ""boundingBox"": [
                                                877,
                                                1018,
                                                893,
                                                1018,
                                                892,
                                                1051,
                                                876,
                                                1051
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                899,
                                                1018,
                                                981,
                                                1016,
                                                979,
                                                1051,
                                                898,
                                                1051
                                            ],
                                            ""text"": ""LIÈGE"",
                                            ""confidence"": 0.992
                                        },
                                        {
                                        ""boundingBox"": [
                                                987,
                                                1016,
                                                1005,
                                                1016,
                                                1003,
                                                1051,
                                                986,
                                                1051
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1338,
                                        1016,
                                        1496,
                                        1016,
                                        1496,
                                        1044,
                                        1338,
                                        1046
                                    ],
                                    ""text"": ""Match Date"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1339,
                                                1017,
                                                1423,
                                                1019,
                                                1422,
                                                1046,
                                                1339,
                                                1046
                                            ],
                                            ""text"": ""Match"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                1429,
                                                1018,
                                                1496,
                                                1017,
                                                1496,
                                                1044,
                                                1429,
                                                1046
                                            ],
                                            ""text"": ""Date"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        319,
                                        1063,
                                        905,
                                        1059,
                                        905,
                                        1090,
                                        319,
                                        1093
                                    ],
                                    ""text"": ""OOST-VLAANDEREN - WEST-VLAANDEREN"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                320,
                                                1064,
                                                591,
                                                1062,
                                                591,
                                                1093,
                                                321,
                                                1093
                                            ],
                                            ""text"": ""OOST-VLAANDEREN"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                603,
                                                1062,
                                                615,
                                                1062,
                                                614,
                                                1093,
                                                603,
                                                1093
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                621,
                                                1062,
                                                897,
                                                1060,
                                                895,
                                                1091,
                                                620,
                                                1093
                                            ],
                                            ""text"": ""WEST-VLAANDEREN"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1376,
                                        1071,
                                        1443,
                                        1071,
                                        1444,
                                        1121,
                                        1378,
                                        1122
                                    ],
                                    ""text"": ""X"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.812
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1392,
                                                1071,
                                                1422,
                                                1071,
                                                1423,
                                                1122,
                                                1392,
                                                1122
                                            ],
                                            ""text"": ""X"",
                                            ""confidence"": 0.959
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1491,
                                        1057,
                                        1562,
                                        1055,
                                        1563,
                                        1118,
                                        1492,
                                        1121
                                    ],
                                    ""text"": ""2"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1501,
                                                1057,
                                                1540,
                                                1055,
                                                1542,
                                                1119,
                                                1504,
                                                1121
                                            ],
                                            ""text"": ""2"",
                                            ""confidence"": 0.96
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        360,
                                        1111,
                                        864,
                                        1109,
                                        864,
                                        1152,
                                        360,
                                        1155
                                    ],
                                    ""text"": ""COMPETITION FORM"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                361,
                                                1112,
                                                686,
                                                1110,
                                                686,
                                                1154,
                                                361,
                                                1156
                                            ],
                                            ""text"": ""COMPETITION"",
                                            ""confidence"": 0.989
                                        },
                                        {
                                        ""boundingBox"": [
                                                707,
                                                1110,
                                                834,
                                                1110,
                                                833,
                                                1153,
                                                707,
                                                1154
                                            ],
                                            ""text"": ""FORM"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1316,
                                        1133,
                                        1525,
                                        1132,
                                        1526,
                                        1159,
                                        1316,
                                        1160
                                    ],
                                    ""text"": ""Snooker Tables"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1318,
                                                1134,
                                                1427,
                                                1133,
                                                1427,
                                                1160,
                                                1318,
                                                1161
                                            ],
                                            ""text"": ""Snooker"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                1432,
                                                1133,
                                                1520,
                                                1132,
                                                1520,
                                                1160,
                                                1432,
                                                1160
                                            ],
                                            ""text"": ""Tables"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        290,
                                        1175,
                                        936,
                                        1173,
                                        936,
                                        1211,
                                        290,
                                        1214
                                    ],
                                    ""text"": ""GIVE FAIR PLAY AND GET RESPECT"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                290,
                                                1177,
                                                374,
                                                1176,
                                                374,
                                                1214,
                                                291,
                                                1214
                                            ],
                                            ""text"": ""GIVE"",
                                            ""confidence"": 0.993
                                        },
                                        {
                                        ""boundingBox"": [
                                                382,
                                                1176,
                                                469,
                                                1176,
                                                469,
                                                1213,
                                                382,
                                                1214
                                            ],
                                            ""text"": ""FAIR"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                480,
                                                1176,
                                                576,
                                                1175,
                                                576,
                                                1213,
                                                479,
                                                1213
                                            ],
                                            ""text"": ""PLAY"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                584,
                                                1175,
                                                669,
                                                1175,
                                                668,
                                                1213,
                                                584,
                                                1213
                                            ],
                                            ""text"": ""AND"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                682,
                                                1175,
                                                756,
                                                1174,
                                                755,
                                                1213,
                                                681,
                                                1213
                                            ],
                                            ""text"": ""GET"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                764,
                                                1174,
                                                932,
                                                1173,
                                                930,
                                                1212,
                                                763,
                                                1213
                                            ],
                                            ""text"": ""RESPECT"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1143,
                                        1189,
                                        1276,
                                        1180,
                                        1278,
                                        1220,
                                        1144,
                                        1237
                                    ],
                                    ""text"": ""19 30"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1143,
                                                1189,
                                                1201,
                                                1183,
                                                1205,
                                                1230,
                                                1146,
                                                1236
                                            ],
                                            ""text"": ""19"",
                                            ""confidence"": 0.764
                                        },
                                        {
                                        ""boundingBox"": [
                                                1213,
                                                1182,
                                                1269,
                                                1180,
                                                1274,
                                                1223,
                                                1218,
                                                1229
                                            ],
                                            ""text"": ""30"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1471,
                                        1181,
                                        1616,
                                        1183,
                                        1618,
                                        1224,
                                        1470,
                                        1237
                                    ],
                                    ""text"": ""100"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.948
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1474,
                                                1181,
                                                1614,
                                                1181,
                                                1616,
                                                1231,
                                                1476,
                                                1236
                                            ],
                                            ""text"": ""100"",
                                            ""confidence"": 0.192
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1135,
                                        1249,
                                        1366,
                                        1248,
                                        1366,
                                        1279,
                                        1135,
                                        1280
                                    ],
                                    ""text"": ""Start Competition"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1136,
                                                1253,
                                                1193,
                                                1252,
                                                1192,
                                                1279,
                                                1135,
                                                1278
                                            ],
                                            ""text"": ""Start"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                1197,
                                                1252,
                                                1360,
                                                1248,
                                                1360,
                                                1280,
                                                1197,
                                                1279
                                            ],
                                            ""text"": ""Competition"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1451,
                                        1247,
                                        1704,
                                        1245,
                                        1704,
                                        1277,
                                        1451,
                                        1279
                                    ],
                                    ""text"": ""End of Competition"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1452,
                                                1248,
                                                1497,
                                                1248,
                                                1497,
                                                1278,
                                                1452,
                                                1278
                                            ],
                                            ""text"": ""End"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                1503,
                                                1248,
                                                1530,
                                                1247,
                                                1530,
                                                1279,
                                                1503,
                                                1278
                                            ],
                                            ""text"": ""of"",
                                            ""confidence"": 0.999
                                        },
                                        {
                                        ""boundingBox"": [
                                                1536,
                                                1247,
                                                1704,
                                                1246,
                                                1703,
                                                1277,
                                                1536,
                                                1279
                                            ],
                                            ""text"": ""Competition"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        121,
                                        1295,
                                        277,
                                        1295,
                                        277,
                                        1323,
                                        121,
                                        1322
                                    ],
                                    ""text"": ""Home team"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                122,
                                                1296,
                                                197,
                                                1295,
                                                196,
                                                1322,
                                                121,
                                                1322
                                            ],
                                            ""text"": ""Home"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                202,
                                                1295,
                                                261,
                                                1296,
                                                261,
                                                1323,
                                                201,
                                                1322
                                            ],
                                            ""text"": ""team"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        285,
                                        1304,
                                        560,
                                        1305,
                                        560,
                                        1367,
                                        285,
                                        1367
                                    ],
                                    ""text"": ""Kanteria E"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.772
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                285,
                                                1305,
                                                486,
                                                1305,
                                                485,
                                                1368,
                                                285,
                                                1368
                                            ],
                                            ""text"": ""Kanteria"",
                                            ""confidence"": 0.432
                                        },
                                        {
                                        ""boundingBox"": [
                                                502,
                                                1305,
                                                539,
                                                1305,
                                                538,
                                                1368,
                                                502,
                                                1368
                                            ],
                                            ""text"": ""E"",
                                            ""confidence"": 0.985
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        732,
                                        1320,
                                        863,
                                        1321,
                                        863,
                                        1367,
                                        732,
                                        1366
                                    ],
                                    ""text"": ""5020"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.495
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                734,
                                                1322,
                                                850,
                                                1322,
                                                847,
                                                1367,
                                                732,
                                                1365
                                            ],
                                            ""text"": ""5020"",
                                            ""confidence"": 0.932
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        918,
                                        1291,
                                        1024,
                                        1293,
                                        1024,
                                        1324,
                                        918,
                                        1322
                                    ],
                                    ""text"": ""Visitors"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                919,
                                                1292,
                                                1024,
                                                1293,
                                                1022,
                                                1325,
                                                918,
                                                1322
                                            ],
                                            ""text"": ""Visitors"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        979,
                                        1310,
                                        1362,
                                        1310,
                                        1362,
                                        1377,
                                        979,
                                        1378
                                    ],
                                    ""text"": ""Buckingham 6"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                980,
                                                1312,
                                                1275,
                                                1311,
                                                1275,
                                                1376,
                                                980,
                                                1379
                                            ],
                                            ""text"": ""Buckingham"",
                                            ""confidence"": 0.887
                                        },
                                        {
                                        ""boundingBox"": [
                                                1297,
                                                1311,
                                                1337,
                                                1312,
                                                1337,
                                                1377,
                                                1297,
                                                1376
                                            ],
                                            ""text"": ""6"",
                                            ""confidence"": 0.575
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1518,
                                        1313,
                                        1648,
                                        1314,
                                        1646,
                                        1360,
                                        1519,
                                        1361
                                    ],
                                    ""text"": ""5073"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1520,
                                                1313,
                                                1642,
                                                1313,
                                                1642,
                                                1361,
                                                1520,
                                                1361
                                            ],
                                            ""text"": ""5073"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        112,
                                        1390,
                                        645,
                                        1405,
                                        643,
                                        1472,
                                        110,
                                        1454
                                    ],
                                    ""text"": ""Player 1 : Bekkers Ronny"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.918
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                115,
                                                1390,
                                                192,
                                                1392,
                                                188,
                                                1457,
                                                110,
                                                1453
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.958
                                        },
                                        {
                                        ""boundingBox"": [
                                                205,
                                                1392,
                                                217,
                                                1392,
                                                213,
                                                1458,
                                                201,
                                                1457
                                            ],
                                            ""text"": ""1"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                230,
                                                1392,
                                                246,
                                                1393,
                                                243,
                                                1459,
                                                226,
                                                1458
                                            ],
                                            ""text"": "":"",
                                            ""confidence"": 0.984
                                        },
                                        {
                                        ""boundingBox"": [
                                                259,
                                                1393,
                                                470,
                                                1400,
                                                467,
                                                1468,
                                                255,
                                                1460
                                            ],
                                            ""text"": ""Bekkers"",
                                            ""confidence"": 0.401
                                        },
                                        {
                                        ""boundingBox"": [
                                                482,
                                                1400,
                                                640,
                                                1407,
                                                638,
                                                1473,
                                                480,
                                                1468
                                            ],
                                            ""text"": ""Ronny"",
                                            ""confidence"": 0.921
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        669,
                                        1412,
                                        723,
                                        1413,
                                        721,
                                        1441,
                                        668,
                                        1439
                                    ],
                                    ""text"": ""no:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                668,
                                                1412,
                                                717,
                                                1413,
                                                717,
                                                1441,
                                                668,
                                                1439
                                            ],
                                            ""text"": ""no:"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        766,
                                        1412,
                                        865,
                                        1414,
                                        864,
                                        1457,
                                        763,
                                        1453
                                    ],
                                    ""text"": ""503"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                766,
                                                1412,
                                                855,
                                                1414,
                                                854,
                                                1457,
                                                765,
                                                1454
                                            ],
                                            ""text"": ""503"",
                                            ""confidence"": 0.998
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        917,
                                        1393,
                                        1533,
                                        1391,
                                        1534,
                                        1453,
                                        918,
                                        1456
                                    ],
                                    ""text"": ""Player 4: 52 Pers Alain no:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.676
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                918,
                                                1404,
                                                996,
                                                1399,
                                                997,
                                                1449,
                                                918,
                                                1443
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                1004,
                                                1399,
                                                1055,
                                                1396,
                                                1056,
                                                1452,
                                                1005,
                                                1450
                                            ],
                                            ""text"": ""4:"",
                                            ""confidence"": 0.96
                                        },
                                        {
                                        ""boundingBox"": [
                                                1073,
                                                1396,
                                                1147,
                                                1393,
                                                1148,
                                                1455,
                                                1074,
                                                1453
                                            ],
                                            ""text"": ""52"",
                                            ""confidence"": 0.108
                                        },
                                        {
                                        ""boundingBox"": [
                                                1158,
                                                1393,
                                                1270,
                                                1392,
                                                1271,
                                                1456,
                                                1158,
                                                1456
                                            ],
                                            ""text"": ""Pers"",
                                            ""confidence"": 0.347
                                        },
                                        {
                                        ""boundingBox"": [
                                                1304,
                                                1392,
                                                1429,
                                                1395,
                                                1430,
                                                1449,
                                                1304,
                                                1455
                                            ],
                                            ""text"": ""Alain"",
                                            ""confidence"": 0.276
                                        },
                                        {
                                        ""boundingBox"": [
                                                1465,
                                                1397,
                                                1526,
                                                1400,
                                                1527,
                                                1440,
                                                1465,
                                                1446
                                            ],
                                            ""text"": ""no:"",
                                            ""confidence"": 0.912
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1572,
                                        1387,
                                        1659,
                                        1391,
                                        1654,
                                        1450,
                                        1567,
                                        1446
                                    ],
                                    ""text"": ""704"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1569,
                                                1387,
                                                1654,
                                                1391,
                                                1652,
                                                1450,
                                                1567,
                                                1446
                                            ],
                                            ""text"": ""704"",
                                            ""confidence"": 0.993
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        113,
                                        1491,
                                        621,
                                        1502,
                                        618,
                                        1558,
                                        113,
                                        1543
                                    ],
                                    ""text"": ""Player 2: Foet Ronny"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.772
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                114,
                                                1494,
                                                192,
                                                1492,
                                                192,
                                                1543,
                                                114,
                                                1536
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                201,
                                                1492,
                                                253,
                                                1491,
                                                252,
                                                1548,
                                                200,
                                                1544
                                            ],
                                            ""text"": ""2:"",
                                            ""confidence"": 0.837
                                        },
                                        {
                                        ""boundingBox"": [
                                                261,
                                                1491,
                                                379,
                                                1494,
                                                378,
                                                1555,
                                                260,
                                                1548
                                            ],
                                            ""text"": ""Foet"",
                                            ""confidence"": 0.785
                                        },
                                        {
                                        ""boundingBox"": [
                                                450,
                                                1497,
                                                609,
                                                1509,
                                                606,
                                                1558,
                                                448,
                                                1557
                                            ],
                                            ""text"": ""Ronny"",
                                            ""confidence"": 0.972
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        669,
                                        1508,
                                        723,
                                        1509,
                                        722,
                                        1539,
                                        670,
                                        1537
                                    ],
                                    ""text"": ""no:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                669,
                                                1508,
                                                720,
                                                1509,
                                                719,
                                                1539,
                                                669,
                                                1537
                                            ],
                                            ""text"": ""no:"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        761,
                                        1501,
                                        902,
                                        1498,
                                        904,
                                        1560,
                                        760,
                                        1562
                                    ],
                                    ""text"": ""504"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 1
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                766,
                                                1500,
                                                878,
                                                1498,
                                                879,
                                                1560,
                                                767,
                                                1562
                                            ],
                                            ""text"": ""504"",
                                            ""confidence"": 0.73
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        917,
                                        1490,
                                        1410,
                                        1493,
                                        1409,
                                        1561,
                                        917,
                                        1551
                                    ],
                                    ""text"": ""Player 5: Stevens Jeg"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.676
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                918,
                                                1496,
                                                995,
                                                1493,
                                                996,
                                                1541,
                                                918,
                                                1540
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                1004,
                                                1493,
                                                1056,
                                                1492,
                                                1056,
                                                1542,
                                                1004,
                                                1541
                                            ],
                                            ""text"": ""5:"",
                                            ""confidence"": 0.858
                                        },
                                        {
                                        ""boundingBox"": [
                                                1087,
                                                1491,
                                                1273,
                                                1491,
                                                1273,
                                                1552,
                                                1088,
                                                1543
                                            ],
                                            ""text"": ""Stevens"",
                                            ""confidence"": 0.87
                                        },
                                        {
                                        ""boundingBox"": [
                                                1307,
                                                1491,
                                                1391,
                                                1493,
                                                1391,
                                                1561,
                                                1308,
                                                1554
                                            ],
                                            ""text"": ""Jeg"",
                                            ""confidence"": 0.399
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1470,
                                        1505,
                                        1522,
                                        1504,
                                        1522,
                                        1531,
                                        1472,
                                        1532
                                    ],
                                    ""text"": ""no:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1471,
                                                1505,
                                                1520,
                                                1504,
                                                1520,
                                                1531,
                                                1471,
                                                1532
                                            ],
                                            ""text"": ""no:"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1585,
                                        1505,
                                        1673,
                                        1507,
                                        1671,
                                        1556,
                                        1584,
                                        1554
                                    ],
                                    ""text"": ""703"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.414
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1585,
                                                1505,
                                                1665,
                                                1507,
                                                1664,
                                                1556,
                                                1584,
                                                1554
                                            ],
                                            ""text"": ""703"",
                                            ""confidence"": 0.965
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        111,
                                        1585,
                                        598,
                                        1586,
                                        596,
                                        1652,
                                        111,
                                        1644
                                    ],
                                    ""text"": ""Player 3: Beckers sheff"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                114,
                                                1591,
                                                194,
                                                1589,
                                                193,
                                                1638,
                                                114,
                                                1632
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                202,
                                                1589,
                                                255,
                                                1588,
                                                254,
                                                1642,
                                                201,
                                                1638
                                            ],
                                            ""text"": ""3:"",
                                            ""confidence"": 0.949
                                        },
                                        {
                                        ""boundingBox"": [
                                                266,
                                                1587,
                                                461,
                                                1586,
                                                459,
                                                1651,
                                                265,
                                                1642
                                            ],
                                            ""text"": ""Beckers"",
                                            ""confidence"": 0.22
                                        },
                                        {
                                        ""boundingBox"": [
                                                488,
                                                1586,
                                                598,
                                                1586,
                                                596,
                                                1653,
                                                486,
                                                1651
                                            ],
                                            ""text"": ""sheff"",
                                            ""confidence"": 0.064
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        669,
                                        1605,
                                        721,
                                        1605,
                                        720,
                                        1631,
                                        669,
                                        1631
                                    ],
                                    ""text"": ""no:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                669,
                                                1605,
                                                717,
                                                1605,
                                                717,
                                                1631,
                                                669,
                                                1631
                                            ],
                                            ""text"": ""no:"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        777,
                                        1597,
                                        898,
                                        1592,
                                        899,
                                        1642,
                                        779,
                                        1643
                                    ],
                                    ""text"": ""501"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 1
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                779,
                                                1595,
                                                876,
                                                1593,
                                                877,
                                                1643,
                                                781,
                                                1644
                                            ],
                                            ""text"": ""501"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        914,
                                        1583,
                                        1375,
                                        1582,
                                        1375,
                                        1634,
                                        915,
                                        1637
                                    ],
                                    ""text"": ""Player 6: Gols Sam"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.772
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                917,
                                                1593,
                                                996,
                                                1587,
                                                996,
                                                1636,
                                                917,
                                                1635
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                1004,
                                                1587,
                                                1056,
                                                1584,
                                                1056,
                                                1637,
                                                1004,
                                                1636
                                            ],
                                            ""text"": ""6:"",
                                            ""confidence"": 0.883
                                        },
                                        {
                                        ""boundingBox"": [
                                                1089,
                                                1583,
                                                1212,
                                                1583,
                                                1211,
                                                1636,
                                                1089,
                                                1637
                                            ],
                                            ""text"": ""Gols"",
                                            ""confidence"": 0.776
                                        },
                                        {
                                        ""boundingBox"": [
                                                1253,
                                                1584,
                                                1351,
                                                1589,
                                                1350,
                                                1633,
                                                1252,
                                                1636
                                            ],
                                            ""text"": ""Sam"",
                                            ""confidence"": 0.87
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1473,
                                        1602,
                                        1520,
                                        1603,
                                        1521,
                                        1626,
                                        1473,
                                        1626
                                    ],
                                    ""text"": ""no:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1473,
                                                1602,
                                                1521,
                                                1602,
                                                1521,
                                                1626,
                                                1473,
                                                1625
                                            ],
                                            ""text"": ""no:"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1587,
                                        1579,
                                        1675,
                                        1580,
                                        1674,
                                        1639,
                                        1586,
                                        1639
                                    ],
                                    ""text"": ""701"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1589,
                                                1579,
                                                1674,
                                                1579,
                                                1674,
                                                1639,
                                                1589,
                                                1639
                                            ],
                                            ""text"": ""701"",
                                            ""confidence"": 0.73
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        116,
                                        1685,
                                        157,
                                        1686,
                                        156,
                                        1707,
                                        115,
                                        1706
                                    ],
                                    ""text"": ""no."",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                115,
                                                1685,
                                                157,
                                                1686,
                                                156,
                                                1707,
                                                115,
                                                1706
                                            ],
                                            ""text"": ""no."",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        217,
                                        1681,
                                        328,
                                        1681,
                                        328,
                                        1710,
                                        217,
                                        1709
                                    ],
                                    ""text"": ""POINTS"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                218,
                                                1682,
                                                324,
                                                1682,
                                                323,
                                                1711,
                                                218,
                                                1710
                                            ],
                                            ""text"": ""POINTS"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        401,
                                        1681,
                                        503,
                                        1682,
                                        503,
                                        1710,
                                        401,
                                        1709
                                    ],
                                    ""text"": ""BREAK"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                402,
                                                1682,
                                                493,
                                                1683,
                                                493,
                                                1710,
                                                401,
                                                1710
                                            ],
                                            ""text"": ""BREAK"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        538,
                                        1682,
                                        655,
                                        1682,
                                        655,
                                        1709,
                                        538,
                                        1709
                                    ],
                                    ""text"": ""POINTS"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                540,
                                                1683,
                                                649,
                                                1682,
                                                649,
                                                1710,
                                                539,
                                                1710
                                            ],
                                            ""text"": ""POINTS"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        725,
                                        1681,
                                        824,
                                        1682,
                                        824,
                                        1709,
                                        725,
                                        1709
                                    ],
                                    ""text"": ""BREAK"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                726,
                                                1682,
                                                817,
                                                1683,
                                                817,
                                                1709,
                                                726,
                                                1710
                                            ],
                                            ""text"": ""BREAK"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        867,
                                        1679,
                                        940,
                                        1679,
                                        940,
                                        1700,
                                        867,
                                        1699
                                    ],
                                    ""text"": ""frames"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                867,
                                                1679,
                                                936,
                                                1680,
                                                935,
                                                1701,
                                                867,
                                                1700
                                            ],
                                            ""text"": ""frames"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        968,
                                        1681,
                                        1078,
                                        1681,
                                        1078,
                                        1710,
                                        968,
                                        1710
                                    ],
                                    ""text"": ""POINTS"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                968,
                                                1681,
                                                1075,
                                                1682,
                                                1075,
                                                1711,
                                                969,
                                                1711
                                            ],
                                            ""text"": ""POINTS"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1132,
                                        1681,
                                        1230,
                                        1681,
                                        1230,
                                        1710,
                                        1132,
                                        1710
                                    ],
                                    ""text"": ""BREAK"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1132,
                                                1682,
                                                1223,
                                                1682,
                                                1222,
                                                1711,
                                                1132,
                                                1710
                                            ],
                                            ""text"": ""BREAK"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1293,
                                        1680,
                                        1405,
                                        1680,
                                        1405,
                                        1709,
                                        1293,
                                        1709
                                    ],
                                    ""text"": ""POINTS"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1294,
                                                1681,
                                                1403,
                                                1681,
                                                1401,
                                                1710,
                                                1294,
                                                1710
                                            ],
                                            ""text"": ""POINTS"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1479,
                                        1680,
                                        1580,
                                        1680,
                                        1580,
                                        1708,
                                        1479,
                                        1709
                                    ],
                                    ""text"": ""BREAK"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1480,
                                                1681,
                                                1573,
                                                1680,
                                                1571,
                                                1709,
                                                1480,
                                                1709
                                            ],
                                            ""text"": ""BREAK"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1672,
                                        1682,
                                        1717,
                                        1682,
                                        1717,
                                        1704,
                                        1671,
                                        1704
                                    ],
                                    ""text"": ""no."",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1672,
                                                1682,
                                                1716,
                                                1682,
                                                1716,
                                                1704,
                                                1672,
                                                1704
                                            ],
                                            ""text"": ""no."",
                                            ""confidence"": 0.963
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        115,
                                        1729,
                                        138,
                                        1732,
                                        136,
                                        1766,
                                        113,
                                        1763
                                    ],
                                    ""text"": ""1"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                117,
                                                1729,
                                                136,
                                                1732,
                                                132,
                                                1765,
                                                113,
                                                1763
                                            ],
                                            ""text"": ""1"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        258,
                                        1741,
                                        307,
                                        1739,
                                        309,
                                        1782,
                                        258,
                                        1781
                                    ],
                                    ""text"": ""61"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                258,
                                                1739,
                                                305,
                                                1739,
                                                305,
                                                1781,
                                                258,
                                                1782
                                            ],
                                            ""text"": ""61"",
                                            ""confidence"": 0.549
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        586,
                                        1736,
                                        642,
                                        1735,
                                        642,
                                        1782,
                                        586,
                                        1781
                                    ],
                                    ""text"": ""58"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.627
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                586,
                                                1735,
                                                638,
                                                1735,
                                                638,
                                                1782,
                                                586,
                                                1782
                                            ],
                                            ""text"": ""58"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        869,
                                        1725,
                                        939,
                                        1725,
                                        940,
                                        1746,
                                        869,
                                        1747
                                    ],
                                    ""text"": ""F1-F10"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                872,
                                                1726,
                                                934,
                                                1725,
                                                933,
                                                1747,
                                                870,
                                                1746
                                            ],
                                            ""text"": ""F1-F10"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1015,
                                        1743,
                                        1042,
                                        1743,
                                        1037,
                                        1784,
                                        1010,
                                        1784
                                    ],
                                    ""text"": ""6"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.785
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1010,
                                                1743,
                                                1034,
                                                1743,
                                                1034,
                                                1784,
                                                1010,
                                                1784
                                            ],
                                            ""text"": ""6"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1329,
                                        1735,
                                        1418,
                                        1737,
                                        1418,
                                        1782,
                                        1328,
                                        1782
                                    ],
                                    ""text"": ""17"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1333,
                                                1735,
                                                1406,
                                                1736,
                                                1405,
                                                1783,
                                                1333,
                                                1782
                                            ],
                                            ""text"": ""17"",
                                            ""confidence"": 0.928
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1694,
                                        1729,
                                        1722,
                                        1732,
                                        1720,
                                        1765,
                                        1692,
                                        1762
                                    ],
                                    ""text"": ""4"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1696,
                                                1729,
                                                1715,
                                                1731,
                                                1711,
                                                1764,
                                                1692,
                                                1762
                                            ],
                                            ""text"": ""4"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        114,
                                        1802,
                                        138,
                                        1801,
                                        137,
                                        1839,
                                        114,
                                        1839
                                    ],
                                    ""text"": ""2"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                114,
                                                1801,
                                                136,
                                                1801,
                                                137,
                                                1839,
                                                114,
                                                1839
                                            ],
                                            ""text"": ""2"",
                                            ""confidence"": 0.989
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        265,
                                        1809,
                                        322,
                                        1810,
                                        319,
                                        1850,
                                        263,
                                        1850
                                    ],
                                    ""text"": ""46"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.969
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                263,
                                                1809,
                                                320,
                                                1809,
                                                319,
                                                1850,
                                                263,
                                                1849
                                            ],
                                            ""text"": ""46"",
                                            ""confidence"": 0.933
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        574,
                                        1811,
                                        640,
                                        1809,
                                        642,
                                        1852,
                                        578,
                                        1857
                                    ],
                                    ""text"": ""53"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                582,
                                                1811,
                                                638,
                                                1809,
                                                640,
                                                1853,
                                                584,
                                                1856
                                            ],
                                            ""text"": ""53"",
                                            ""confidence"": 0.998
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        872,
                                        1794,
                                        938,
                                        1795,
                                        938,
                                        1816,
                                        872,
                                        1816
                                    ],
                                    ""text"": ""F2-F11"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                873,
                                                1795,
                                                935,
                                                1795,
                                                934,
                                                1817,
                                                873,
                                                1817
                                            ],
                                            ""text"": ""F2-F11"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1006,
                                        1812,
                                        1061,
                                        1816,
                                        1061,
                                        1851,
                                        1003,
                                        1849
                                    ],
                                    ""text"": ""55"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1007,
                                                1812,
                                                1058,
                                                1815,
                                                1056,
                                                1852,
                                                1005,
                                                1849
                                            ],
                                            ""text"": ""55"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1338,
                                        1809,
                                        1397,
                                        1811,
                                        1395,
                                        1849,
                                        1337,
                                        1847
                                    ],
                                    ""text"": ""20"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.785
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1338,
                                                1809,
                                                1391,
                                                1811,
                                                1389,
                                                1849,
                                                1337,
                                                1847
                                            ],
                                            ""text"": ""20"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1697,
                                        1797,
                                        1718,
                                        1799,
                                        1719,
                                        1836,
                                        1698,
                                        1834
                                    ],
                                    ""text"": ""6"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1699,
                                                1797,
                                                1720,
                                                1799,
                                                1716,
                                                1835,
                                                1697,
                                                1833
                                            ],
                                            ""text"": ""6"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        111,
                                        1874,
                                        138,
                                        1875,
                                        137,
                                        1912,
                                        110,
                                        1911
                                    ],
                                    ""text"": ""3"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                113,
                                                1874,
                                                134,
                                                1875,
                                                133,
                                                1912,
                                                111,
                                                1911
                                            ],
                                            ""text"": ""3"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        268,
                                        1872,
                                        347,
                                        1869,
                                        348,
                                        1928,
                                        269,
                                        1930
                                    ],
                                    ""text"": ""39"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 1
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                270,
                                                1871,
                                                337,
                                                1869,
                                                339,
                                                1928,
                                                272,
                                                1930
                                            ],
                                            ""text"": ""39"",
                                            ""confidence"": 0.55
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        872,
                                        1867,
                                        938,
                                        1867,
                                        938,
                                        1887,
                                        872,
                                        1886
                                    ],
                                    ""text"": ""F3-F12"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                873,
                                                1867,
                                                933,
                                                1868,
                                                933,
                                                1887,
                                                872,
                                                1886
                                            ],
                                            ""text"": ""F3-F12"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        432,
                                        1890,
                                        466,
                                        1890,
                                        466,
                                        1909,
                                        431,
                                        1908
                                    ],
                                    ""text"": ""-"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                432,
                                                1890,
                                                443,
                                                1890,
                                                443,
                                                1909,
                                                432,
                                                1908
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        584,
                                        1884,
                                        636,
                                        1878,
                                        641,
                                        1919,
                                        587,
                                        1923
                                    ],
                                    ""text"": ""68"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                584,
                                                1882,
                                                632,
                                                1878,
                                                636,
                                                1919,
                                                587,
                                                1924
                                            ],
                                            ""text"": ""68"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1003,
                                        1878,
                                        1075,
                                        1882,
                                        1074,
                                        1927,
                                        1001,
                                        1926
                                    ],
                                    ""text"": ""63"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.785
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1004,
                                                1878,
                                                1065,
                                                1880,
                                                1064,
                                                1928,
                                                1003,
                                                1925
                                            ],
                                            ""text"": ""63"",
                                            ""confidence"": 0.976
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1694,
                                        1871,
                                        1721,
                                        1871,
                                        1721,
                                        1906,
                                        1693,
                                        1906
                                    ],
                                    ""text"": ""5"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1695,
                                                1871,
                                                1718,
                                                1871,
                                                1718,
                                                1906,
                                                1695,
                                                1906
                                            ],
                                            ""text"": ""5"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        112,
                                        1946,
                                        137,
                                        1945,
                                        136,
                                        1985,
                                        111,
                                        1985
                                    ],
                                    ""text"": ""2"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                112,
                                                1945,
                                                134,
                                                1945,
                                                135,
                                                1985,
                                                113,
                                                1985
                                            ],
                                            ""text"": ""2"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        259,
                                        1940,
                                        339,
                                        1942,
                                        338,
                                        2004,
                                        258,
                                        2002
                                    ],
                                    ""text"": ""29"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.676
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                262,
                                                1940,
                                                328,
                                                1942,
                                                327,
                                                2004,
                                                261,
                                                2002
                                            ],
                                            ""text"": ""29"",
                                            ""confidence"": 0.185
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        870,
                                        1940,
                                        936,
                                        1941,
                                        936,
                                        1960,
                                        870,
                                        1960
                                    ],
                                    ""text"": ""F4-F13"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                871,
                                                1941,
                                                934,
                                                1941,
                                                933,
                                                1961,
                                                870,
                                                1960
                                            ],
                                            ""text"": ""F4-F13"",
                                            ""confidence"": 0.942
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        997,
                                        1952,
                                        1074,
                                        1954,
                                        1070,
                                        2013,
                                        994,
                                        2011
                                    ],
                                    ""text"": ""50"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1006,
                                                1952,
                                                1072,
                                                1954,
                                                1070,
                                                2013,
                                                1004,
                                                2011
                                            ],
                                            ""text"": ""50"",
                                            ""confidence"": 0.949
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1698,
                                        1951,
                                        1722,
                                        1951,
                                        1721,
                                        1981,
                                        1697,
                                        1980
                                    ],
                                    ""text"": ""4"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1699,
                                                1951,
                                                1716,
                                                1951,
                                                1715,
                                                1981,
                                                1698,
                                                1980
                                            ],
                                            ""text"": ""4"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        112,
                                        2018,
                                        137,
                                        2018,
                                        136,
                                        2056,
                                        111,
                                        2056
                                    ],
                                    ""text"": ""3"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                111,
                                                2018,
                                                135,
                                                2018,
                                                135,
                                                2056,
                                                111,
                                                2056
                                            ],
                                            ""text"": ""3"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        257,
                                        2014,
                                        352,
                                        2014,
                                        352,
                                        2080,
                                        257,
                                        2080
                                    ],
                                    ""text"": ""51"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                260,
                                                2014,
                                                338,
                                                2014,
                                                338,
                                                2080,
                                                260,
                                                2080
                                            ],
                                            ""text"": ""51"",
                                            ""confidence"": 0.925
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        870,
                                        2012,
                                        937,
                                        2012,
                                        937,
                                        2031,
                                        870,
                                        2031
                                    ],
                                    ""text"": ""F5-F14"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                872,
                                                2013,
                                                933,
                                                2012,
                                                932,
                                                2032,
                                                871,
                                                2031
                                            ],
                                            ""text"": ""F5-F14"",
                                            ""confidence"": 0.991
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1701,
                                        2021,
                                        1724,
                                        2020,
                                        1724,
                                        2052,
                                        1700,
                                        2052
                                    ],
                                    ""text"": ""6"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1700,
                                                2020,
                                                1720,
                                                2020,
                                                1720,
                                                2052,
                                                1700,
                                                2052
                                            ],
                                            ""text"": ""6"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        109,
                                        2094,
                                        136,
                                        2096,
                                        135,
                                        2132,
                                        109,
                                        2130
                                    ],
                                    ""text"": ""1"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                111,
                                                2094,
                                                132,
                                                2096,
                                                129,
                                                2131,
                                                109,
                                                2130
                                            ],
                                            ""text"": ""1"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        259,
                                        2095,
                                        344,
                                        2089,
                                        348,
                                        2152,
                                        263,
                                        2158
                                    ],
                                    ""text"": ""42"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                266,
                                                2095,
                                                342,
                                                2089,
                                                347,
                                                2152,
                                                270,
                                                2157
                                            ],
                                            ""text"": ""42"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        868,
                                        2083,
                                        937,
                                        2084,
                                        937,
                                        2104,
                                        868,
                                        2103
                                    ],
                                    ""text"": ""F6-F15"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                870,
                                                2084,
                                                934,
                                                2085,
                                                934,
                                                2104,
                                                869,
                                                2103
                                            ],
                                            ""text"": ""F6-F15"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1015,
                                        2101,
                                        1093,
                                        2096,
                                        1090,
                                        2143,
                                        1015,
                                        2145
                                    ],
                                    ""text"": ""35"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.844
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1015,
                                                2099,
                                                1072,
                                                2096,
                                                1074,
                                                2143,
                                                1017,
                                                2146
                                            ],
                                            ""text"": ""35"",
                                            ""confidence"": 0.995
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1696,
                                        2094,
                                        1724,
                                        2094,
                                        1724,
                                        2128,
                                        1696,
                                        2128
                                    ],
                                    ""text"": ""5"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1700,
                                                2094,
                                                1720,
                                                2094,
                                                1720,
                                                2128,
                                                1700,
                                                2128
                                            ],
                                            ""text"": ""5"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        109,
                                        2168,
                                        134,
                                        2167,
                                        133,
                                        2205,
                                        108,
                                        2206
                                    ],
                                    ""text"": ""3"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                108,
                                                2168,
                                                130,
                                                2167,
                                                131,
                                                2204,
                                                110,
                                                2205
                                            ],
                                            ""text"": ""3"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        247,
                                        2165,
                                        316,
                                        2163,
                                        319,
                                        2219,
                                        250,
                                        2221
                                    ],
                                    ""text"": ""42"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.357
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                249,
                                                2165,
                                                317,
                                                2163,
                                                319,
                                                2219,
                                                251,
                                                2221
                                            ],
                                            ""text"": ""42"",
                                            ""confidence"": 0.863
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        872,
                                        2159,
                                        938,
                                        2159,
                                        938,
                                        2178,
                                        872,
                                        2179
                                    ],
                                    ""text"": ""F7-F16"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                873,
                                                2160,
                                                933,
                                                2160,
                                                933,
                                                2179,
                                                873,
                                                2179
                                            ],
                                            ""text"": ""F7-F16"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        997,
                                        2159,
                                        1065,
                                        2164,
                                        1059,
                                        2223,
                                        992,
                                        2218
                                    ],
                                    ""text"": ""26"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.844
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                996,
                                                2159,
                                                1062,
                                                2164,
                                                1057,
                                                2222,
                                                992,
                                                2218
                                            ],
                                            ""text"": ""26"",
                                            ""confidence"": 0.958
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1700,
                                        2170,
                                        1729,
                                        2174,
                                        1726,
                                        2206,
                                        1697,
                                        2202
                                    ],
                                    ""text"": ""4"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1702,
                                                2170,
                                                1720,
                                                2173,
                                                1716,
                                                2204,
                                                1697,
                                                2202
                                            ],
                                            ""text"": ""4"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        107,
                                        2238,
                                        134,
                                        2236,
                                        134,
                                        2276,
                                        108,
                                        2278
                                    ],
                                    ""text"": ""1"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                107,
                                                2238,
                                                130,
                                                2236,
                                                132,
                                                2275,
                                                110,
                                                2277
                                            ],
                                            ""text"": ""1"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        252,
                                        2242,
                                        308,
                                        2241,
                                        308,
                                        2295,
                                        252,
                                        2297
                                    ],
                                    ""text"": ""45"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.909
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                252,
                                                2242,
                                                304,
                                                2241,
                                                306,
                                                2295,
                                                252,
                                                2296
                                            ],
                                            ""text"": ""45"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        870,
                                        2230,
                                        938,
                                        2231,
                                        938,
                                        2250,
                                        869,
                                        2250
                                    ],
                                    ""text"": ""F8-F17"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                870,
                                                2231,
                                                935,
                                                2232,
                                                934,
                                                2251,
                                                870,
                                                2250
                                            ],
                                            ""text"": ""F8-F17"",
                                            ""confidence"": 0.986
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        427,
                                        2259,
                                        463,
                                        2258,
                                        462,
                                        2278,
                                        426,
                                        2279
                                    ],
                                    ""text"": ""-"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                426,
                                                2259,
                                                438,
                                                2259,
                                                439,
                                                2279,
                                                427,
                                                2279
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1023,
                                        2249,
                                        1051,
                                        2246,
                                        1048,
                                        2286,
                                        1019,
                                        2289
                                    ],
                                    ""text"": ""5"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1019,
                                                2249,
                                                1039,
                                                2247,
                                                1043,
                                                2286,
                                                1021,
                                                2288
                                            ],
                                            ""text"": ""5"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1180,
                                        2249,
                                        1227,
                                        2248,
                                        1226,
                                        2274,
                                        1179,
                                        2276
                                    ],
                                    ""text"": ""-"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1179,
                                                2249,
                                                1195,
                                                2248,
                                                1196,
                                                2275,
                                                1180,
                                                2276
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.972
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1702,
                                        2241,
                                        1726,
                                        2241,
                                        1726,
                                        2273,
                                        1702,
                                        2273
                                    ],
                                    ""text"": ""6"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1702,
                                                2241,
                                                1722,
                                                2241,
                                                1722,
                                                2273,
                                                1702,
                                                2273
                                            ],
                                            ""text"": ""6"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        107,
                                        2312,
                                        134,
                                        2312,
                                        133,
                                        2351,
                                        107,
                                        2352
                                    ],
                                    ""text"": ""2"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                107,
                                                2312,
                                                132,
                                                2312,
                                                132,
                                                2352,
                                                107,
                                                2352
                                            ],
                                            ""text"": ""2"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        869,
                                        2303,
                                        935,
                                        2302,
                                        935,
                                        2323,
                                        869,
                                        2323
                                    ],
                                    ""text"": ""F9-F18"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                871,
                                                2304,
                                                933,
                                                2303,
                                                933,
                                                2324,
                                                870,
                                                2323
                                            ],
                                            ""text"": ""F9-F18"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1004,
                                        2305,
                                        1076,
                                        2305,
                                        1075,
                                        2373,
                                        1003,
                                        2372
                                    ],
                                    ""text"": ""29"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""handwriting"",
                                            ""confidence"": 0.938
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1006,
                                                2305,
                                                1074,
                                                2305,
                                                1074,
                                                2373,
                                                1006,
                                                2373
                                            ],
                                            ""text"": ""29"",
                                            ""confidence"": 0.464
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1702,
                                        2316,
                                        1728,
                                        2316,
                                        1728,
                                        2350,
                                        1702,
                                        2350
                                    ],
                                    ""text"": ""5"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1704,
                                                2316,
                                                1724,
                                                2316,
                                                1724,
                                                2350,
                                                1704,
                                                2350
                                            ],
                                            ""text"": ""5"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1309,
                                        2390,
                                        1554,
                                        2390,
                                        1554,
                                        2432,
                                        1309,
                                        2432
                                    ],
                                    ""text"": ""- SCORE -"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1311,
                                                2393,
                                                1334,
                                                2392,
                                                1333,
                                                2432,
                                                1311,
                                                2432
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                1360,
                                                2391,
                                                1504,
                                                2391,
                                                1502,
                                                2432,
                                                1359,
                                                2433
                                            ],
                                            ""text"": ""SCORE"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                1517,
                                                2392,
                                                1539,
                                                2393,
                                                1538,
                                                2431,
                                                1516,
                                                2432
                                            ],
                                            ""text"": ""-"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        105,
                                        2423,
                                        265,
                                        2422,
                                        265,
                                        2450,
                                        105,
                                        2450
                                    ],
                                    ""text"": ""Comments :."",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                106,
                                                2423,
                                                245,
                                                2423,
                                                245,
                                                2451,
                                                105,
                                                2450
                                            ],
                                            ""text"": ""Comments"",
                                            ""confidence"": 0.995
                                        },
                                        {
                                        ""boundingBox"": [
                                                251,
                                                2423,
                                                265,
                                                2423,
                                                264,
                                                2451,
                                                250,
                                                2451
                                            ],
                                            ""text"": "":."",
                                            ""confidence"": 0.925
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1532,
                                        2497,
                                        1587,
                                        2497,
                                        1584,
                                        2551,
                                        1531,
                                        2550
                                    ],
                                    ""text"": ""3"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1537,
                                                2497,
                                                1569,
                                                2497,
                                                1568,
                                                2551,
                                                1537,
                                                2551
                                            ],
                                            ""text"": ""3"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        520,
                                        2581,
                                        1306,
                                        2580,
                                        1307,
                                        2614,
                                        520,
                                        2616
                                    ],
                                    ""text"": ""Signatures apply to \""read and approved\"" of all stated data."",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                521,
                                                2584,
                                                658,
                                                2582,
                                                658,
                                                2615,
                                                521,
                                                2614
                                            ],
                                            ""text"": ""Signatures"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                664,
                                                2582,
                                                738,
                                                2582,
                                                738,
                                                2616,
                                                664,
                                                2615
                                            ],
                                            ""text"": ""apply"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                744,
                                                2582,
                                                776,
                                                2581,
                                                776,
                                                2616,
                                                744,
                                                2616
                                            ],
                                            ""text"": ""to"",
                                            ""confidence"": 0.999
                                        },
                                        {
                                        ""boundingBox"": [
                                                782,
                                                2581,
                                                856,
                                                2581,
                                                856,
                                                2616,
                                                782,
                                                2616
                                            ],
                                            ""text"": ""\""read"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                862,
                                                2581,
                                                914,
                                                2581,
                                                914,
                                                2616,
                                                862,
                                                2616
                                            ],
                                            ""text"": ""and"",
                                            ""confidence"": 0.999
                                        },
                                        {
                                        ""boundingBox"": [
                                                920,
                                                2581,
                                                1064,
                                                2581,
                                                1064,
                                                2615,
                                                920,
                                                2616
                                            ],
                                            ""text"": ""approved\"""",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                1070,
                                                2581,
                                                1100,
                                                2581,
                                                1100,
                                                2615,
                                                1070,
                                                2615
                                            ],
                                            ""text"": ""of"",
                                            ""confidence"": 0.997
                                        },
                                        {
                                        ""boundingBox"": [
                                                1106,
                                                2581,
                                                1138,
                                                2581,
                                                1138,
                                                2615,
                                                1106,
                                                2615
                                            ],
                                            ""text"": ""all"",
                                            ""confidence"": 0.998
                                        },
                                        {
                                        ""boundingBox"": [
                                                1144,
                                                2581,
                                                1230,
                                                2581,
                                                1230,
                                                2614,
                                                1144,
                                                2615
                                            ],
                                            ""text"": ""stated"",
                                            ""confidence"": 0.996
                                        },
                                        {
                                        ""boundingBox"": [
                                                1236,
                                                2581,
                                                1307,
                                                2582,
                                                1307,
                                                2613,
                                                1236,
                                                2614
                                            ],
                                            ""text"": ""data."",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        103,
                                        2620,
                                        367,
                                        2621,
                                        367,
                                        2653,
                                        103,
                                        2652
                                    ],
                                    ""text"": ""Captain home team"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                104,
                                                2621,
                                                199,
                                                2621,
                                                199,
                                                2652,
                                                104,
                                                2653
                                            ],
                                            ""text"": ""Captain"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                205,
                                                2621,
                                                284,
                                                2621,
                                                283,
                                                2652,
                                                205,
                                                2652
                                            ],
                                            ""text"": ""home"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                291,
                                                2621,
                                                353,
                                                2623,
                                                351,
                                                2653,
                                                290,
                                                2652
                                            ],
                                            ""text"": ""team"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        656,
                                        2623,
                                        761,
                                        2623,
                                        761,
                                        2652,
                                        656,
                                        2651
                                    ],
                                    ""text"": ""Referee"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                656,
                                                2624,
                                                758,
                                                2624,
                                                757,
                                                2653,
                                                656,
                                                2652
                                            ],
                                            ""text"": ""Referee"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1185,
                                        2623,
                                        1394,
                                        2623,
                                        1394,
                                        2655,
                                        1185,
                                        2655
                                    ],
                                    ""text"": ""Captain visitors"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1186,
                                                2624,
                                                1285,
                                                2624,
                                                1284,
                                                2655,
                                                1187,
                                                2656
                                            ],
                                            ""text"": ""Captain"",
                                            ""confidence"": 0.994
                                        },
                                        {
                                        ""boundingBox"": [
                                                1291,
                                                2624,
                                                1393,
                                                2624,
                                                1392,
                                                2655,
                                                1291,
                                                2655
                                            ],
                                            ""text"": ""visitors"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        101,
                                        2784,
                                        187,
                                        2787,
                                        185,
                                        2816,
                                        100,
                                        2813
                                    ],
                                    ""text"": ""Player"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                101,
                                                2784,
                                                186,
                                                2787,
                                                185,
                                                2816,
                                                100,
                                                2813
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        384,
                                        2780,
                                        413,
                                        2781,
                                        410,
                                        2821,
                                        382,
                                        2819
                                    ],
                                    ""text"": ""2"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                386,
                                                2780,
                                                411,
                                                2781,
                                                409,
                                                2821,
                                                384,
                                                2819
                                            ],
                                            ""text"": ""2"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        530,
                                        2783,
                                        551,
                                        2784,
                                        550,
                                        2815,
                                        529,
                                        2814
                                    ],
                                    ""text"": ""3"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                532,
                                                2783,
                                                550,
                                                2784,
                                                548,
                                                2815,
                                                530,
                                                2814
                                            ],
                                            ""text"": ""3"",
                                            ""confidence"": 0.998
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        652,
                                        2792,
                                        746,
                                        2793,
                                        746,
                                        2820,
                                        652,
                                        2820
                                    ],
                                    ""text"": ""Name:"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                653,
                                                2793,
                                                746,
                                                2793,
                                                745,
                                                2820,
                                                653,
                                                2819
                                            ],
                                            ""text"": ""Name:"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1186,
                                        2788,
                                        1273,
                                        2790,
                                        1272,
                                        2819,
                                        1185,
                                        2817
                                    ],
                                    ""text"": ""Player"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1186,
                                                2788,
                                                1272,
                                                2790,
                                                1271,
                                                2819,
                                                1186,
                                                2817
                                            ],
                                            ""text"": ""Player"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1358,
                                        2787,
                                        1382,
                                        2791,
                                        1379,
                                        2819,
                                        1355,
                                        2815
                                    ],
                                    ""text"": ""4"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1359,
                                                2787,
                                                1375,
                                                2790,
                                                1371,
                                                2817,
                                                1355,
                                                2815
                                            ],
                                            ""text"": ""4"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1477,
                                        2793,
                                        1500,
                                        2791,
                                        1500,
                                        2818,
                                        1477,
                                        2820
                                    ],
                                    ""text"": ""5"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1479,
                                                2793,
                                                1494,
                                                2791,
                                                1497,
                                                2817,
                                                1482,
                                                2819
                                            ],
                                            ""text"": ""5"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1622,
                                        2791,
                                        1643,
                                        2791,
                                        1642,
                                        2818,
                                        1621,
                                        2818
                                    ],
                                    ""text"": ""6"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1622,
                                                2791,
                                                1638,
                                                2791,
                                                1638,
                                                2818,
                                                1622,
                                                2818
                                            ],
                                            ""text"": ""6"",
                                            ""confidence"": 0.997
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1351,
                                        2866,
                                        1452,
                                        2895,
                                        1441,
                                        2928,
                                        1343,
                                        2891
                                    ],
                                    ""text"": ""D & SHOCKERCESTO"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.821
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1349,
                                                2867,
                                                1351,
                                                2867,
                                                1345,
                                                2893,
                                                1343,
                                                2893
                                            ],
                                            ""text"": ""D"",
                                            ""confidence"": 0.394
                                        },
                                        {
                                        ""boundingBox"": [
                                                1355,
                                                2867,
                                                1363,
                                                2868,
                                                1357,
                                                2895,
                                                1350,
                                                2894
                                            ],
                                            ""text"": ""&"",
                                            ""confidence"": 0.499
                                        },
                                        {
                                        ""boundingBox"": [
                                                1368,
                                                2869,
                                                1450,
                                                2902,
                                                1441,
                                                2928,
                                                1362,
                                                2895
                                            ],
                                            ""text"": ""SHOCKERCESTO"",
                                            ""confidence"": 0.054
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        387,
                                        2928,
                                        448,
                                        2927,
                                        448,
                                        2949,
                                        385,
                                        2951
                                    ],
                                    ""text"": ""IBSF"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                393,
                                                2928,
                                                442,
                                                2927,
                                                442,
                                                2950,
                                                394,
                                                2951
                                            ],
                                            ""text"": ""IBSF"",
                                            ""confidence"": 0.986
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        620,
                                        2939,
                                        885,
                                        2934,
                                        886,
                                        2984,
                                        621,
                                        2985
                                    ],
                                    ""text"": ""aramith"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                621,
                                                2946,
                                                854,
                                                2936,
                                                853,
                                                2985,
                                                622,
                                                2983
                                            ],
                                            ""text"": ""aramith"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        929,
                                        2922,
                                        1249,
                                        2920,
                                        1249,
                                        2990,
                                        930,
                                        2992
                                    ],
                                    ""text"": ""Strachan"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                933,
                                                2922,
                                                1238,
                                                2921,
                                                1238,
                                                2991,
                                                934,
                                                2993
                                            ],
                                            ""text"": ""Strachan"",
                                            ""confidence"": 0.963
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1316,
                                        2943,
                                        1445,
                                        2947,
                                        1444,
                                        2983,
                                        1316,
                                        2981
                                    ],
                                    ""text"": ""EBSA*"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1316,
                                                2943,
                                                1436,
                                                2949,
                                                1438,
                                                2983,
                                                1316,
                                                2982
                                            ],
                                            ""text"": ""EBSA*"",
                                            ""confidence"": 0.242
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        623,
                                        2979,
                                        877,
                                        2982,
                                        877,
                                        3007,
                                        623,
                                        3003
                                    ],
                                    ""text"": ""BILLIARD BALLS"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                623,
                                                2979,
                                                758,
                                                2983,
                                                758,
                                                3006,
                                                624,
                                                3004
                                            ],
                                            ""text"": ""BILLIARD"",
                                            ""confidence"": 0.968
                                        },
                                        {
                                        ""boundingBox"": [
                                                780,
                                                2983,
                                                871,
                                                2983,
                                                871,
                                                3007,
                                                780,
                                                3006
                                            ],
                                            ""text"": ""BALLS"",
                                            ""confidence"": 0.996
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        134,
                                        3010,
                                        211,
                                        3009,
                                        211,
                                        3030,
                                        134,
                                        3032
                                    ],
                                    ""text"": ""TEAM"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                137,
                                                3011,
                                                197,
                                                3010,
                                                196,
                                                3031,
                                                137,
                                                3032
                                            ],
                                            ""text"": ""TEAM"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1518,
                                        2993,
                                        1665,
                                        2990,
                                        1666,
                                        3021,
                                        1518,
                                        3026
                                    ],
                                    ""text"": ""WORLD"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1522,
                                                2994,
                                                1648,
                                                2991,
                                                1648,
                                                3021,
                                                1520,
                                                3027
                                            ],
                                            ""text"": ""WORLD"",
                                            ""confidence"": 0.995
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        119,
                                        3030,
                                        229,
                                        3030,
                                        229,
                                        3053,
                                        119,
                                        3054
                                    ],
                                    ""text"": ""BELGIUM"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                120,
                                                3031,
                                                218,
                                                3030,
                                                218,
                                                3053,
                                                119,
                                                3055
                                            ],
                                            ""text"": ""BELGIUM"",
                                            ""confidence"": 0.994
                                        }
                                    ]
                                },
                                {
                                    ""boundingBox"": [
                                        1520,
                                        3008,
                                        1709,
                                        3012,
                                        1708,
                                        3043,
                                        1519,
                                        3039
                                    ],
                                    ""text"": ""SNOOKER"",
                                    ""appearance"": {
                                        ""style"": {
                                            ""name"": ""other"",
                                            ""confidence"": 0.878
                                        }
                                    },
                                    ""words"": [
                                        {
                                        ""boundingBox"": [
                                                1524,
                                                3008,
                                                1693,
                                                3015,
                                                1693,
                                                3042,
                                                1521,
                                                3040
                                            ],
                                            ""text"": ""SNOOKER"",
                                            ""confidence"": 0.24
                                        }
                                    ]
                                }
                            ],
                            ""selectionMarks"": [
                                {
                                    ""boundingBox"": [
                                        1235,
                                        909,
                                        1251,
                                        909,
                                        1251,
                                        926,
                                        1235,
                                        926
                                    ],
                                    ""confidence"": 0.213,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        742,
                                        1025,
                                        760,
                                        1025,
                                        760,
                                        1047,
                                        742,
                                        1047
                                    ],
                                    ""confidence"": 0.212,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        321,
                                        1068,
                                        341,
                                        1068,
                                        341,
                                        1089,
                                        321,
                                        1089
                                    ],
                                    ""confidence"": 0.3,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1406,
                                        1079,
                                        1438,
                                        1079,
                                        1438,
                                        1116,
                                        1406,
                                        1116
                                    ],
                                    ""confidence"": 0.394,
                                    ""state"": ""selected""
                                },
                                {
                                    ""boundingBox"": [
                                        1320,
                                        1403,
                                        1340,
                                        1403,
                                        1340,
                                        1426,
                                        1320,
                                        1426
                                    ],
                                    ""confidence"": 0.347,
                                    ""state"": ""selected""
                                },
                                {
                                    ""boundingBox"": [
                                        1269,
                                        1607,
                                        1286,
                                        1607,
                                        1286,
                                        1623,
                                        1269,
                                        1623
                                    ],
                                    ""confidence"": 0.54,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        428,
                                        1728,
                                        474,
                                        1728,
                                        474,
                                        1762,
                                        428,
                                        1762
                                    ],
                                    ""confidence"": 0.245,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1165,
                                        1733,
                                        1218,
                                        1733,
                                        1218,
                                        1766,
                                        1165,
                                        1766
                                    ],
                                    ""confidence"": 0.245,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1521,
                                        1728,
                                        1570,
                                        1728,
                                        1570,
                                        1761,
                                        1521,
                                        1761
                                    ],
                                    ""confidence"": 0.394,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1613,
                                        1718,
                                        1729,
                                        1718,
                                        1729,
                                        1789,
                                        1613,
                                        1789
                                    ],
                                    ""confidence"": 0.223,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        758,
                                        1800,
                                        811,
                                        1800,
                                        811,
                                        1836,
                                        758,
                                        1836
                                    ],
                                    ""confidence"": 0.204,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1171,
                                        1802,
                                        1221,
                                        1802,
                                        1221,
                                        1834,
                                        1171,
                                        1834
                                    ],
                                    ""confidence"": 0.223,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1515,
                                        1794,
                                        1560,
                                        1794,
                                        1560,
                                        1830,
                                        1515,
                                        1830
                                    ],
                                    ""confidence"": 0.347,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        436,
                                        1877,
                                        464,
                                        1877,
                                        464,
                                        1901,
                                        436,
                                        1901
                                    ],
                                    ""confidence"": 0.212,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1178,
                                        1870,
                                        1218,
                                        1870,
                                        1218,
                                        1904,
                                        1178,
                                        1904
                                    ],
                                    ""confidence"": 0.347,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        754,
                                        1940,
                                        821,
                                        1940,
                                        821,
                                        1979,
                                        754,
                                        1979
                                    ],
                                    ""confidence"": 0.292,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1511,
                                        1954,
                                        1559,
                                        1954,
                                        1559,
                                        1986,
                                        1511,
                                        1986
                                    ],
                                    ""confidence"": 0.335,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        439,
                                        2014,
                                        479,
                                        2014,
                                        479,
                                        2053,
                                        439,
                                        2053
                                    ],
                                    ""confidence"": 0.41,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        590,
                                        2014,
                                        629,
                                        2014,
                                        629,
                                        2046,
                                        590,
                                        2046
                                    ],
                                    ""confidence"": 0.223,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        766,
                                        2025,
                                        808,
                                        2025,
                                        808,
                                        2057,
                                        766,
                                        2057
                                    ],
                                    ""confidence"": 0.5,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1350,
                                        2016,
                                        1397,
                                        2016,
                                        1397,
                                        2049,
                                        1350,
                                        2049
                                    ],
                                    ""confidence"": 0.347,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1528,
                                        2016,
                                        1568,
                                        2016,
                                        1568,
                                        2052,
                                        1528,
                                        2052
                                    ],
                                    ""confidence"": 0.223,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1618,
                                        2082,
                                        1726,
                                        2082,
                                        1726,
                                        2147,
                                        1618,
                                        2147
                                    ],
                                    ""confidence"": 0.251,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        431,
                                        2169,
                                        473,
                                        2169,
                                        473,
                                        2194,
                                        431,
                                        2194
                                    ],
                                    ""confidence"": 0.347,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        757,
                                        2164,
                                        802,
                                        2164,
                                        802,
                                        2190,
                                        757,
                                        2190
                                    ],
                                    ""confidence"": 0.394,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1624,
                                        2161,
                                        1726,
                                        2161,
                                        1726,
                                        2225,
                                        1624,
                                        2225
                                    ],
                                    ""confidence"": 0.223,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        429,
                                        2241,
                                        459,
                                        2241,
                                        459,
                                        2272,
                                        429,
                                        2272
                                    ],
                                    ""confidence"": 0.347,
                                    ""state"": ""unselected""
                                },
                                {
                                    ""boundingBox"": [
                                        1524,
                                        2240,
                                        1573,
                                        2240,
                                        1573,
                                        2273,
                                        1524,
                                        2273
                                    ],
                                    ""confidence"": 0.221,
                                    ""state"": ""unselected""
                                }
                            ]
                        }
                    ],
                    ""pageResults"": [
                        {
                                ""page"": 1,
                            ""tables"": [
                                {
                                    ""rows"": 10,
                                    ""columns"": 11,
                                    ""cells"": [
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 0,
                                            ""text"": ""no."",
                                            ""boundingBox"": [
                                                99,
                                                1670,
                                                202,
                                                1670,
                                                200,
                                                1717,
                                                98,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/46/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 1,
                                            ""text"": ""POINTS"",
                                            ""boundingBox"": [
                                                202,
                                                1670,
                                                385,
                                                1672,
                                                384,
                                                1717,
                                                200,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/47/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 2,
                                            ""text"": ""BREAK"",
                                            ""boundingBox"": [
                                                385,
                                                1672,
                                                528,
                                                1672,
                                                528,
                                                1717,
                                                384,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/48/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 3,
                                            ""text"": ""POINTS"",
                                            ""boundingBox"": [
                                                528,
                                                1672,
                                                710,
                                                1672,
                                                710,
                                                1717,
                                                528,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/49/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 4,
                                            ""text"": ""BREAK"",
                                            ""boundingBox"": [
                                                710,
                                                1672,
                                                853,
                                                1672,
                                                853,
                                                1717,
                                                710,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/50/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 5,
                                            ""text"": ""frames"",
                                            ""boundingBox"": [
                                                853,
                                                1672,
                                                953,
                                                1670,
                                                953,
                                                1717,
                                                853,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/51/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 6,
                                            ""text"": ""POINTS"",
                                            ""boundingBox"": [
                                                953,
                                                1670,
                                                1115,
                                                1670,
                                                1115,
                                                1717,
                                                953,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/52/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 7,
                                            ""text"": ""BREAK"",
                                            ""boundingBox"": [
                                                1115,
                                                1670,
                                                1278,
                                                1668,
                                                1278,
                                                1716,
                                                1115,
                                                1717
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/53/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 8,
                                            ""text"": ""POINTS"",
                                            ""boundingBox"": [
                                                1278,
                                                1668,
                                                1462,
                                                1668,
                                                1464,
                                                1714,
                                                1278,
                                                1716
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/54/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 9,
                                            ""text"": ""BREAK"",
                                            ""boundingBox"": [
                                                1462,
                                                1668,
                                                1607,
                                                1668,
                                                1608,
                                                1714,
                                                1464,
                                                1714
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/55/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 10,
                                            ""text"": ""no."",
                                            ""boundingBox"": [
                                                1607,
                                                1668,
                                                1733,
                                                1668,
                                                1733,
                                                1714,
                                                1608,
                                                1714
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/56/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 0,
                                            ""text"": ""1"",
                                            ""boundingBox"": [
                                                98,
                                                1717,
                                                200,
                                                1717,
                                                200,
                                                1789,
                                                98,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/57/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 1,
                                            ""text"": ""61"",
                                            ""boundingBox"": [
                                                200,
                                                1717,
                                                384,
                                                1717,
                                                384,
                                                1789,
                                                200,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/58/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                384,
                                                1717,
                                                528,
                                                1717,
                                                526,
                                                1789,
                                                384,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/6""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 3,
                                            ""text"": ""58"",
                                            ""boundingBox"": [
                                                528,
                                                1717,
                                                710,
                                                1717,
                                                710,
                                                1790,
                                                526,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/59/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                1717,
                                                853,
                                                1717,
                                                853,
                                                1790,
                                                710,
                                                1790
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 5,
                                            ""text"": ""F1-F10"",
                                            ""boundingBox"": [
                                                853,
                                                1717,
                                                953,
                                                1717,
                                                953,
                                                1789,
                                                853,
                                                1790
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/60/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 6,
                                            ""text"": ""6"",
                                            ""boundingBox"": [
                                                953,
                                                1717,
                                                1115,
                                                1717,
                                                1115,
                                                1789,
                                                953,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/61/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1115,
                                                1717,
                                                1278,
                                                1716,
                                                1278,
                                                1789,
                                                1115,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/7""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 8,
                                            ""text"": ""17"",
                                            ""boundingBox"": [
                                                1278,
                                                1716,
                                                1464,
                                                1714,
                                                1464,
                                                1787,
                                                1278,
                                                1789
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/62/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1464,
                                                1714,
                                                1608,
                                                1714,
                                                1608,
                                                1787,
                                                1464,
                                                1787
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/8""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 10,
                                            ""text"": ""4"",
                                            ""boundingBox"": [
                                                1608,
                                                1714,
                                                1733,
                                                1714,
                                                1733,
                                                1787,
                                                1608,
                                                1787
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/63/words/0"",
                                                ""#/readResults/0/selectionMarks/9""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 0,
                                            ""text"": ""2"",
                                            ""boundingBox"": [
                                                98,
                                                1789,
                                                200,
                                                1789,
                                                200,
                                                1860,
                                                96,
                                                1862
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/64/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 1,
                                            ""text"": ""46"",
                                            ""boundingBox"": [
                                                200,
                                                1789,
                                                384,
                                                1789,
                                                384,
                                                1860,
                                                200,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/65/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                384,
                                                1789,
                                                526,
                                                1789,
                                                526,
                                                1860,
                                                384,
                                                1860
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 3,
                                            ""text"": ""53"",
                                            ""boundingBox"": [
                                                526,
                                                1789,
                                                710,
                                                1790,
                                                710,
                                                1860,
                                                526,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/66/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                1790,
                                                853,
                                                1790,
                                                853,
                                                1860,
                                                710,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/10""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 5,
                                            ""text"": ""F2-F11"",
                                            ""boundingBox"": [
                                                853,
                                                1790,
                                                953,
                                                1789,
                                                953,
                                                1860,
                                                853,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/67/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 6,
                                            ""text"": ""55"",
                                            ""boundingBox"": [
                                                953,
                                                1789,
                                                1115,
                                                1789,
                                                1115,
                                                1860,
                                                953,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/68/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1115,
                                                1789,
                                                1278,
                                                1789,
                                                1280,
                                                1860,
                                                1115,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/11""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 8,
                                            ""text"": ""20"",
                                            ""boundingBox"": [
                                                1278,
                                                1789,
                                                1464,
                                                1787,
                                                1465,
                                                1860,
                                                1280,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/69/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1464,
                                                1787,
                                                1608,
                                                1787,
                                                1610,
                                                1860,
                                                1465,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/12""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 10,
                                            ""text"": ""6"",
                                            ""boundingBox"": [
                                                1608,
                                                1787,
                                                1733,
                                                1787,
                                                1734,
                                                1860,
                                                1610,
                                                1860
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/70/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 0,
                                            ""text"": ""3"",
                                            ""boundingBox"": [
                                                96,
                                                1862,
                                                200,
                                                1860,
                                                198,
                                                1933,
                                                94,
                                                1935
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/71/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 1,
                                            ""text"": ""39"",
                                            ""boundingBox"": [
                                                200,
                                                1860,
                                                384,
                                                1860,
                                                382,
                                                1933,
                                                198,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/72/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 2,
                                            ""text"": ""-"",
                                            ""boundingBox"": [
                                                384,
                                                1860,
                                                526,
                                                1860,
                                                526,
                                                1933,
                                                382,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/74/words/0"",
                                                ""#/readResults/0/selectionMarks/13""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 3,
                                            ""text"": ""68"",
                                            ""boundingBox"": [
                                                526,
                                                1860,
                                                710,
                                                1860,
                                                710,
                                                1933,
                                                526,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/75/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                1860,
                                                853,
                                                1860,
                                                853,
                                                1933,
                                                710,
                                                1933
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 5,
                                            ""text"": ""F3-F12"",
                                            ""boundingBox"": [
                                                853,
                                                1860,
                                                953,
                                                1860,
                                                953,
                                                1933,
                                                853,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/73/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 6,
                                            ""text"": ""63"",
                                            ""boundingBox"": [
                                                953,
                                                1860,
                                                1115,
                                                1860,
                                                1115,
                                                1933,
                                                953,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/76/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1115,
                                                1860,
                                                1280,
                                                1860,
                                                1280,
                                                1933,
                                                1115,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/14""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1280,
                                                1860,
                                                1465,
                                                1860,
                                                1465,
                                                1933,
                                                1280,
                                                1933
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1465,
                                                1860,
                                                1610,
                                                1860,
                                                1612,
                                                1933,
                                                1465,
                                                1933
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 10,
                                            ""text"": ""5"",
                                            ""boundingBox"": [
                                                1610,
                                                1860,
                                                1734,
                                                1860,
                                                1734,
                                                1933,
                                                1612,
                                                1933
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/77/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 0,
                                            ""text"": ""2"",
                                            ""boundingBox"": [
                                                94,
                                                1935,
                                                198,
                                                1933,
                                                198,
                                                2006,
                                                94,
                                                2008
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/78/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 1,
                                            ""text"": ""29"",
                                            ""boundingBox"": [
                                                198,
                                                1933,
                                                382,
                                                1933,
                                                382,
                                                2006,
                                                198,
                                                2006
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/79/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                382,
                                                1933,
                                                526,
                                                1933,
                                                525,
                                                2006,
                                                382,
                                                2006
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 3,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                526,
                                                1933,
                                                710,
                                                1933,
                                                710,
                                                2006,
                                                525,
                                                2006
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                1933,
                                                853,
                                                1933,
                                                853,
                                                2006,
                                                710,
                                                2006
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/15""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 5,
                                            ""text"": ""F4-F13"",
                                            ""boundingBox"": [
                                                853,
                                                1933,
                                                953,
                                                1933,
                                                953,
                                                2006,
                                                853,
                                                2006
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/80/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 6,
                                            ""text"": ""50"",
                                            ""boundingBox"": [
                                                953,
                                                1933,
                                                1115,
                                                1933,
                                                1117,
                                                2006,
                                                953,
                                                2006
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/81/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1115,
                                                1933,
                                                1280,
                                                1933,
                                                1282,
                                                2006,
                                                1117,
                                                2006
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1280,
                                                1933,
                                                1465,
                                                1933,
                                                1467,
                                                2006,
                                                1282,
                                                2006
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1465,
                                                1933,
                                                1612,
                                                1933,
                                                1612,
                                                2006,
                                                1467,
                                                2006
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/16""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 4,
                                            ""columnIndex"": 10,
                                            ""text"": ""4"",
                                            ""boundingBox"": [
                                                1612,
                                                1933,
                                                1734,
                                                1933,
                                                1736,
                                                2006,
                                                1612,
                                                2006
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/82/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 0,
                                            ""text"": ""3"",
                                            ""boundingBox"": [
                                                94,
                                                2008,
                                                198,
                                                2006,
                                                196,
                                                2079,
                                                93,
                                                2079
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/83/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 1,
                                            ""text"": ""51"",
                                            ""boundingBox"": [
                                                198,
                                                2006,
                                                382,
                                                2006,
                                                382,
                                                2077,
                                                196,
                                                2079
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/84/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                382,
                                                2006,
                                                525,
                                                2006,
                                                525,
                                                2077,
                                                382,
                                                2077
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/17""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 3,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                525,
                                                2006,
                                                710,
                                                2006,
                                                710,
                                                2077,
                                                525,
                                                2077
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/18""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                2006,
                                                853,
                                                2006,
                                                853,
                                                2077,
                                                710,
                                                2077
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/19""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 5,
                                            ""text"": ""F5-F14"",
                                            ""boundingBox"": [
                                                853,
                                                2006,
                                                953,
                                                2006,
                                                953,
                                                2077,
                                                853,
                                                2077
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/85/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 6,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                953,
                                                2006,
                                                1117,
                                                2006,
                                                1117,
                                                2077,
                                                953,
                                                2077
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1117,
                                                2006,
                                                1282,
                                                2006,
                                                1282,
                                                2077,
                                                1117,
                                                2077
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1282,
                                                2006,
                                                1467,
                                                2006,
                                                1467,
                                                2079,
                                                1282,
                                                2077
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/20""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1467,
                                                2006,
                                                1612,
                                                2006,
                                                1613,
                                                2079,
                                                1467,
                                                2079
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/21""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 5,
                                            ""columnIndex"": 10,
                                            ""text"": ""6"",
                                            ""boundingBox"": [
                                                1612,
                                                2006,
                                                1736,
                                                2006,
                                                1736,
                                                2079,
                                                1613,
                                                2079
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/86/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 0,
                                            ""text"": ""1"",
                                            ""boundingBox"": [
                                                93,
                                                2079,
                                                196,
                                                2079,
                                                196,
                                                2152,
                                                93,
                                                2152
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/87/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 1,
                                            ""text"": ""42"",
                                            ""boundingBox"": [
                                                196,
                                                2079,
                                                382,
                                                2077,
                                                382,
                                                2150,
                                                196,
                                                2152
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/88/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                382,
                                                2077,
                                                525,
                                                2077,
                                                525,
                                                2150,
                                                382,
                                                2150
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 3,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                525,
                                                2077,
                                                710,
                                                2077,
                                                710,
                                                2150,
                                                525,
                                                2150
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                2077,
                                                853,
                                                2077,
                                                853,
                                                2150,
                                                710,
                                                2150
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 5,
                                            ""text"": ""F6-F15"",
                                            ""boundingBox"": [
                                                853,
                                                2077,
                                                953,
                                                2077,
                                                953,
                                                2150,
                                                853,
                                                2150
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/89/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 6,
                                            ""text"": ""35"",
                                            ""boundingBox"": [
                                                953,
                                                2077,
                                                1117,
                                                2077,
                                                1117,
                                                2150,
                                                953,
                                                2150
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/90/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1117,
                                                2077,
                                                1282,
                                                2077,
                                                1282,
                                                2152,
                                                1117,
                                                2150
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1282,
                                                2077,
                                                1467,
                                                2079,
                                                1469,
                                                2152,
                                                1282,
                                                2152
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1467,
                                                2079,
                                                1613,
                                                2079,
                                                1613,
                                                2152,
                                                1469,
                                                2152
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 6,
                                            ""columnIndex"": 10,
                                            ""text"": ""5"",
                                            ""boundingBox"": [
                                                1613,
                                                2079,
                                                1736,
                                                2079,
                                                1738,
                                                2154,
                                                1613,
                                                2152
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/91/words/0"",
                                                ""#/readResults/0/selectionMarks/22""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 0,
                                            ""text"": ""3"",
                                            ""boundingBox"": [
                                                93,
                                                2152,
                                                196,
                                                2152,
                                                195,
                                                2225,
                                                91,
                                                2227
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/92/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 1,
                                            ""text"": ""42"",
                                            ""boundingBox"": [
                                                196,
                                                2152,
                                                382,
                                                2150,
                                                380,
                                                2225,
                                                195,
                                                2225
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/93/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                382,
                                                2150,
                                                525,
                                                2150,
                                                523,
                                                2225,
                                                380,
                                                2225
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/23""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 3,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                525,
                                                2150,
                                                710,
                                                2150,
                                                710,
                                                2225,
                                                523,
                                                2225
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                2150,
                                                853,
                                                2150,
                                                853,
                                                2225,
                                                710,
                                                2225
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/24""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 5,
                                            ""text"": ""F7-F16"",
                                            ""boundingBox"": [
                                                853,
                                                2150,
                                                953,
                                                2150,
                                                953,
                                                2225,
                                                853,
                                                2225
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/94/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 6,
                                            ""text"": ""26"",
                                            ""boundingBox"": [
                                                953,
                                                2150,
                                                1117,
                                                2150,
                                                1117,
                                                2225,
                                                953,
                                                2225
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/95/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1117,
                                                2150,
                                                1282,
                                                2152,
                                                1283,
                                                2225,
                                                1117,
                                                2225
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1282,
                                                2152,
                                                1469,
                                                2152,
                                                1469,
                                                2227,
                                                1283,
                                                2225
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1469,
                                                2152,
                                                1613,
                                                2152,
                                                1615,
                                                2227,
                                                1469,
                                                2227
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 7,
                                            ""columnIndex"": 10,
                                            ""text"": ""4"",
                                            ""boundingBox"": [
                                                1613,
                                                2152,
                                                1738,
                                                2154,
                                                1739,
                                                2227,
                                                1615,
                                                2227
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/96/words/0"",
                                                ""#/readResults/0/selectionMarks/25""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 0,
                                            ""text"": ""1"",
                                            ""boundingBox"": [
                                                91,
                                                2227,
                                                195,
                                                2225,
                                                195,
                                                2298,
                                                89,
                                                2300
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/97/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 1,
                                            ""text"": ""45"",
                                            ""boundingBox"": [
                                                195,
                                                2225,
                                                380,
                                                2225,
                                                380,
                                                2298,
                                                195,
                                                2298
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/98/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 2,
                                            ""text"": ""-"",
                                            ""boundingBox"": [
                                                380,
                                                2225,
                                                523,
                                                2225,
                                                523,
                                                2298,
                                                380,
                                                2298
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/100/words/0"",
                                                ""#/readResults/0/selectionMarks/26""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 3,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                523,
                                                2225,
                                                710,
                                                2225,
                                                708,
                                                2298,
                                                523,
                                                2298
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                710,
                                                2225,
                                                853,
                                                2225,
                                                853,
                                                2298,
                                                708,
                                                2298
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 5,
                                            ""text"": ""F8-F17"",
                                            ""boundingBox"": [
                                                853,
                                                2225,
                                                953,
                                                2225,
                                                955,
                                                2298,
                                                853,
                                                2298
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/99/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 6,
                                            ""text"": ""5"",
                                            ""boundingBox"": [
                                                953,
                                                2225,
                                                1117,
                                                2225,
                                                1118,
                                                2298,
                                                955,
                                                2298
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/101/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 7,
                                            ""text"": ""-"",
                                            ""boundingBox"": [
                                                1117,
                                                2225,
                                                1283,
                                                2225,
                                                1283,
                                                2298,
                                                1118,
                                                2298
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/102/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1283,
                                                2225,
                                                1469,
                                                2227,
                                                1471,
                                                2300,
                                                1283,
                                                2298
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1469,
                                                2227,
                                                1615,
                                                2227,
                                                1617,
                                                2300,
                                                1471,
                                                2300
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/selectionMarks/27""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 8,
                                            ""columnIndex"": 10,
                                            ""text"": ""6"",
                                            ""boundingBox"": [
                                                1615,
                                                2227,
                                                1739,
                                                2227,
                                                1739,
                                                2301,
                                                1617,
                                                2300
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/103/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 0,
                                            ""text"": ""2"",
                                            ""boundingBox"": [
                                                89,
                                                2300,
                                                195,
                                                2298,
                                                195,
                                                2373,
                                                89,
                                                2374
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/104/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 1,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                195,
                                                2298,
                                                380,
                                                2298,
                                                380,
                                                2373,
                                                195,
                                                2373
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 2,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                380,
                                                2298,
                                                523,
                                                2298,
                                                523,
                                                2373,
                                                380,
                                                2373
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 3,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                523,
                                                2298,
                                                708,
                                                2298,
                                                708,
                                                2373,
                                                523,
                                                2373
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 4,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                708,
                                                2298,
                                                853,
                                                2298,
                                                853,
                                                2373,
                                                708,
                                                2373
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 5,
                                            ""text"": ""F9-F18"",
                                            ""boundingBox"": [
                                                853,
                                                2298,
                                                955,
                                                2298,
                                                955,
                                                2373,
                                                853,
                                                2373
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/105/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 6,
                                            ""text"": ""29"",
                                            ""boundingBox"": [
                                                955,
                                                2298,
                                                1118,
                                                2298,
                                                1118,
                                                2373,
                                                955,
                                                2373
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/106/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 7,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1118,
                                                2298,
                                                1283,
                                                2298,
                                                1285,
                                                2373,
                                                1118,
                                                2373
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 8,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1283,
                                                2298,
                                                1471,
                                                2300,
                                                1471,
                                                2374,
                                                1285,
                                                2373
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 9,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                1471,
                                                2300,
                                                1617,
                                                2300,
                                                1617,
                                                2374,
                                                1471,
                                                2374
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 9,
                                            ""columnIndex"": 10,
                                            ""text"": ""5"",
                                            ""boundingBox"": [
                                                1617,
                                                2300,
                                                1739,
                                                2301,
                                                1741,
                                                2376,
                                                1617,
                                                2374
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/107/words/0""
                                            ],
                                            ""isHeader"": false
                                        }
                                    ],
                                    ""boundingBox"": [
                                        88,
                                        1668,
                                        1746,
                                        1668,
                                        1746,
                                        2383,
                                        87,
                                        2382
                                    ]
                                },
                                {
                                    ""rows"": 4,
                                    ""columns"": 7,
                                    ""cells"": [
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 0,
                                            ""text"": ""Home team Kanteria E"",
                                            ""boundingBox"": [
                                                105,
                                                1286,
                                                647,
                                                1286,
                                                645,
                                                1382,
                                                105,
                                                1382
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/23/words/0"",
                                                ""#/readResults/0/lines/23/words/1"",
                                                ""#/readResults/0/lines/24/words/0"",
                                                ""#/readResults/0/lines/24/words/1""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 1,
                                            ""text"": """",
                                            ""boundingBox"": [
                                                647,
                                                1286,
                                                730,
                                                1284,
                                                730,
                                                1382,
                                                645,
                                                1382
                                            ],
                                            ""elements"": [],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 2,
                                            ""text"": ""5020"",
                                            ""boundingBox"": [
                                                730,
                                                1284,
                                                905,
                                                1284,
                                                905,
                                                1382,
                                                730,
                                                1382
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/25/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 3,
                                            ""columnSpan"": 2,
                                            ""text"": ""Visitors Buckingham 6"",
                                            ""boundingBox"": [
                                                905,
                                                1284,
                                                1455,
                                                1281,
                                                1455,
                                                1379,
                                                905,
                                                1382
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/26/words/0"",
                                                ""#/readResults/0/lines/27/words/0"",
                                                ""#/readResults/0/lines/27/words/1""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 0,
                                            ""columnIndex"": 5,
                                            ""columnSpan"": 2,
                                            ""text"": ""5073"",
                                            ""boundingBox"": [
                                                1455,
                                                1281,
                                                1728,
                                                1279,
                                                1730,
                                                1379,
                                                1455,
                                                1379
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/28/words/0""
                                            ],
                                            ""isHeader"": true
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 0,
                                            ""text"": ""Player 1 : Bekkers Ronny"",
                                            ""boundingBox"": [
                                                105,
                                                1382,
                                                645,
                                                1382,
                                                645,
                                                1479,
                                                103,
                                                1479
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/29/words/0"",
                                                ""#/readResults/0/lines/29/words/1"",
                                                ""#/readResults/0/lines/29/words/2"",
                                                ""#/readResults/0/lines/29/words/3"",
                                                ""#/readResults/0/lines/29/words/4""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 1,
                                            ""text"": ""no:"",
                                            ""boundingBox"": [
                                                645,
                                                1382,
                                                730,
                                                1382,
                                                730,
                                                1479,
                                                645,
                                                1479
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/30/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 2,
                                            ""text"": ""503"",
                                            ""boundingBox"": [
                                                730,
                                                1382,
                                                905,
                                                1382,
                                                905,
                                                1479,
                                                730,
                                                1479
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/31/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 3,
                                            ""columnSpan"": 2,
                                            ""text"": ""Player 4: 52 Pers Alain"",
                                            ""boundingBox"": [
                                                905,
                                                1382,
                                                1455,
                                                1379,
                                                1455,
                                                1475,
                                                905,
                                                1479
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/32/words/0"",
                                                ""#/readResults/0/lines/32/words/1"",
                                                ""#/readResults/0/lines/32/words/2"",
                                                ""#/readResults/0/lines/32/words/3"",
                                                ""#/readResults/0/lines/32/words/4"",
                                                ""#/readResults/0/selectionMarks/4""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 5,
                                            ""text"": ""no:"",
                                            ""boundingBox"": [
                                                1455,
                                                1379,
                                                1540,
                                                1379,
                                                1542,
                                                1475,
                                                1455,
                                                1475
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/32/words/5""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 1,
                                            ""columnIndex"": 6,
                                            ""text"": ""704"",
                                            ""boundingBox"": [
                                                1540,
                                                1379,
                                                1730,
                                                1379,
                                                1730,
                                                1475,
                                                1542,
                                                1475
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/33/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 0,
                                            ""text"": ""Player 2: Foet Ronny"",
                                            ""boundingBox"": [
                                                103,
                                                1479,
                                                645,
                                                1479,
                                                645,
                                                1575,
                                                102,
                                                1574
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/34/words/0"",
                                                ""#/readResults/0/lines/34/words/1"",
                                                ""#/readResults/0/lines/34/words/2"",
                                                ""#/readResults/0/lines/34/words/3""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 1,
                                            ""text"": ""no:"",
                                            ""boundingBox"": [
                                                645,
                                                1479,
                                                730,
                                                1479,
                                                730,
                                                1575,
                                                645,
                                                1575
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/35/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 2,
                                            ""text"": ""504"",
                                            ""boundingBox"": [
                                                730,
                                                1479,
                                                905,
                                                1479,
                                                905,
                                                1575,
                                                730,
                                                1575
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/36/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 3,
                                            ""columnSpan"": 2,
                                            ""text"": ""Player 5: Stevens Jeg"",
                                            ""boundingBox"": [
                                                905,
                                                1479,
                                                1455,
                                                1475,
                                                1455,
                                                1572,
                                                905,
                                                1575
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/37/words/0"",
                                                ""#/readResults/0/lines/37/words/1"",
                                                ""#/readResults/0/lines/37/words/2"",
                                                ""#/readResults/0/lines/37/words/3""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 5,
                                            ""text"": ""no:"",
                                            ""boundingBox"": [
                                                1455,
                                                1475,
                                                1542,
                                                1475,
                                                1544,
                                                1572,
                                                1455,
                                                1572
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/38/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 2,
                                            ""columnIndex"": 6,
                                            ""text"": ""703"",
                                            ""boundingBox"": [
                                                1542,
                                                1475,
                                                1730,
                                                1475,
                                                1730,
                                                1570,
                                                1544,
                                                1572
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/39/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 0,
                                            ""text"": ""Player 3: Beckers sheff"",
                                            ""boundingBox"": [
                                                102,
                                                1574,
                                                645,
                                                1575,
                                                645,
                                                1672,
                                                100,
                                                1670
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/40/words/0"",
                                                ""#/readResults/0/lines/40/words/1"",
                                                ""#/readResults/0/lines/40/words/2"",
                                                ""#/readResults/0/lines/40/words/3""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 1,
                                            ""text"": ""no:"",
                                            ""boundingBox"": [
                                                645,
                                                1575,
                                                730,
                                                1575,
                                                730,
                                                1672,
                                                645,
                                                1672
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/41/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 2,
                                            ""text"": ""501"",
                                            ""boundingBox"": [
                                                730,
                                                1575,
                                                905,
                                                1575,
                                                906,
                                                1672,
                                                730,
                                                1672
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/42/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 3,
                                            ""columnSpan"": 2,
                                            ""text"": ""Player 6: Gols Sam"",
                                            ""boundingBox"": [
                                                905,
                                                1575,
                                                1455,
                                                1572,
                                                1455,
                                                1668,
                                                906,
                                                1672
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/43/words/0"",
                                                ""#/readResults/0/lines/43/words/1"",
                                                ""#/readResults/0/lines/43/words/2"",
                                                ""#/readResults/0/lines/43/words/3"",
                                                ""#/readResults/0/selectionMarks/5""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 5,
                                            ""text"": ""no:"",
                                            ""boundingBox"": [
                                                1455,
                                                1572,
                                                1544,
                                                1572,
                                                1544,
                                                1668,
                                                1455,
                                                1668
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/44/words/0""
                                            ],
                                            ""isHeader"": false
                                        },
                                        {
                                        ""rowIndex"": 3,
                                            ""columnIndex"": 6,
                                            ""text"": ""701"",
                                            ""boundingBox"": [
                                                1544,
                                                1572,
                                                1730,
                                                1570,
                                                1730,
                                                1668,
                                                1544,
                                                1668
                                            ],
                                            ""elements"": [
                                                ""#/readResults/0/lines/45/words/0""
                                            ],
                                            ""isHeader"": false
                                        }
                                    ],
                                    ""boundingBox"": [
                                        99,
                                        1274,
                                        1733,
                                        1268,
                                        1735,
                                        1669,
                                        101,
                                        1675
                                    ]
                                }
                            ]
                        }
                    ]
                }
            }";

            return Task.FromResult(responseMessage.ToString());
        }
    }
}