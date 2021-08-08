using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer;

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

            string formPageJson = @"
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
            }";

            FormPage formPage = JsonConvert.DeserializeObject<FormPage>(formPageJson);

            FormTable formTable = formPage.Tables.FirstOrDefault(x => x.RowCount == 10 && x.ColumnCount == 11);

            return Task.FromResult(responseMessage.ToString());
        }
    }
}