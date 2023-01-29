﻿/*
 * Copyright(c) 2022 MoogleTroupe, GiR-Zippo
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

using System.Collections.Generic;

namespace BardMusicPlayer.Seer.Reader.Backend.Machina;

internal static class World
{
    // Updated as of commit 7d17810 Aug 13 2020
    // https://github.com/xivapi/ffxiv-datamining/blob/master/csv/World.csv

    internal static readonly IReadOnlyDictionary<int, string> Ids = new Dictionary<int, string>
    {
        { 21, "Ravana" },
        { 22, "Bismarck" },
        { 23, "Asura" },
        { 24, "Belias" },
        { 25, "Chaos" },
        { 26, "Hecatoncheir" },
        { 27, "Moomba" },
        { 28, "Pandaemonium" },
        { 29, "Shinryu" },
        { 30, "Unicorn" },
        { 31, "Yojimbo" },
        { 32, "Zeromus" },
        { 33, "Twintania" },
        { 34, "Brynhildr" },
        { 35, "Famfrit" },
        { 36, "Lich" },
        { 37, "Mateus" },
        { 38, "Shemhazai" },
        { 39, "Omega" },
        { 40, "Jenova" },
        { 41, "Zalera" },
        { 42, "Zodiark" },
        { 43, "Alexander" },
        { 44, "Anima" },
        { 45, "Carbuncle" },
        { 46, "Fenrir" },
        { 47, "Hades" },
        { 48, "Ixion" },
        { 49, "Kujata" },
        { 50, "Typhon" },
        { 51, "Ultima" },
        { 52, "Valefor" },
        { 53, "Exodus" },
        { 54, "Faerie" },
        { 55, "Lamia" },
        { 56, "Phoenix" },
        { 57, "Siren" },
        { 58, "Garuda" },
        { 59, "Ifrit" },
        { 60, "Ramuh" },
        { 61, "Titan" },
        { 62, "Diabolos" },
        { 63, "Gilgamesh" },
        { 64, "Leviathan" },
        { 65, "Midgardsormr" },
        { 66, "Odin" },
        { 67, "Shiva" },
        { 68, "Atomos" },
        { 69, "Bahamut" },
        { 70, "Chocobo" },
        { 71, "Moogle" },
        { 72, "Tonberry" },
        { 73, "Adamantoise" },
        { 74, "Coeurl" },
        { 75, "Malboro" },
        { 76, "Tiamat" },
        { 77, "Ultros" },
        { 78, "Behemoth" },
        { 79, "Cactuar" },
        { 80, "Cerberus" },
        { 81, "Goblin" },
        { 82, "Mandragora" },
        { 83, "Louisoix" },
        { 84, "Syldra" },
        { 85, "Spriggan" },
        { 86, "Sephirot" },
        { 87, "Sophia" },
        { 88, "Zurvan" },
        { 90, "Aegis" },
        { 91, "Balmung" },
        { 92, "Durandal" },
        { 93, "Excalibur" },
        { 94, "Gungnir" },
        { 95, "Hyperion" },
        { 96, "Masamune" },
        { 97, "Ragnarok" },
        { 98, "Ridill" },
        { 99, "Sargatanas" },

        { 161, "Chocobo" },

        { 166, "Moogle" },

        { 168, "Namazu" },

        { 400, "Sagittarius" },
        { 401, "Phantom" },
        { 402, "Alpha" },
        { 403, "Raiden" },

        { 1040, "DiPingGuan" },
        { 1041, "MiWuShiDi" },
        { 1042, "LaNuoXiYa" },
        { 1043, "ZiShuiZhanQiao" },
        { 1044, "HuanYingQunDao" },
        { 1045, "MoDuNa" },
        { 1046, "MoShouLingYu" },
        { 1047, "FengMoDong" },
        { 1048, "TaiyangHaiAn" },
        { 1049, "XiaoMaiJiuGang" },
        { 1050, "YinLeiHu" },
        { 1051, "ShengXiaTan" },
        { 1052, "PuTaoJiuGang" },
        { 1053, "HeiYiSenLin" },
        { 1054, "QingLinQuan" },
        { 1055, "JinChuiTaiDi" },
        { 1056, "HongChaChuan" },
        { 1057, "YiXiuJiaDe" },
        { 1058, "XueSongYuan" },
        { 1059, "YaoJingLing" },
        { 1060, "MengYaChi" },
        { 1061, "ZhiZhangXiaGu" },
        { 1062, "MiYueZhiTa" },
        { 1063, "MoLaBiWan" },
        { 1064, "YueYaWan" },
        { 1065, "YaoLanShu" },
        { 1066, "QiaoMingDong" },
        { 1067, "NiMuHe" },
        { 1068, "HuangJinGu" },
        { 1069, "BaiLingTi" },
        { 1070, "TianLangXingDengTa" },
        { 1071, "ZhuoReZouLang" },
        { 1072, "SiYuJuMu" },
        { 1073, "YueYingDao" },
        { 1074, "ShuiJingTa" },
        { 1075, "MengXiangGong" },
        { 1076, "BaiJinHuanXiang" },
        { 1077, "HeiJinHu" },
        { 1078, "LongXiPuBu" },
        { 1079, "ShiWeiTa" },
        { 1080, "TongLingTongShan" },
        { 1081, "ShenYiZhiDi" },
        { 1082, "ShiJiuDaQiao" },
        { 1083, "YongHengChuan" },
        { 1084, "HaiWuShaTan" },
        { 1085, "HeFengLiuDi" },
        { 1086, "ZeMeiErYaoSai" },
        { 1087, "JuShiQiu" },
        { 1088, "JianDouLingYu" },
        { 1089, "HeiChenYiZhan" },
        { 1090, "ShuiLianYan" },
        { 1091, "LingHangMingDeng" },
        { 1092, "HaiCiShiKu" },
        { 1093, "FeiCuiHu" },
        { 1094, "XiongXinGuangChang" },
        { 1095, "KuErZhaSi" },
        { 1096, "LiuShaMiGong" },
        { 1097, "FangXiangTang" },
        { 1098, "HuaMiZhanQiao" },
        { 1099, "LanWuYongQuan" },
        { 1100, "ShenLingShengYu" },
        { 1101, "BaiYunYa" },
        { 1102, "HaiJiangShuiQu" },
        { 1103, "YuanLingYouShu" },
        { 1104, "ShaZhongLuTing" },
        { 1105, "JieMeiQiu" },
        { 1106, "JingYuZhuangYuan" },
        { 1107, "ZuJiGu" },
        { 1108, "ShanHuTa" },
        { 1109, "HengDuanYa" },
        { 1110, "ShuiShangTingYuan" },
        { 1111, "WuXianHuiLang" },
        { 1112, "JinDingChi" },
        { 1113, "LvRenZhanQiao" },
        { 1114, "LongWenYan" },
        { 1115, "HaiManQiaoLang" },
        { 1116, "YuanQuanZhiTi" },
        { 1117, "MiShiTa" },
        { 1118, "RiShengMen" },
        { 1119, "XiFengJia" },
        { 1120, "ShenLiZhiMen" },
        { 1121, "FuXiaoZhiJian" },
        { 1122, "HaiLangDong" },
        { 1123, "XiangShuYuan" },
        { 1124, "MoNvKaFeiGuan" },
        { 1125, "JuLongShouYingDi" },
        { 1126, "DiYuHeGu" },
        { 1127, "FuRongYuanZhuo" },
        { 1128, "ShenWoJiao" },
        { 1129, "HuangJinGuangChang" },
        { 1130, "WanZhiMuChang" },
        { 1131, "QiMuQuan" },
        { 1132, "JingChiZhanQiao" },
        { 1133, "BaiOuTA" },
        { 1134, "XiaoShiWangDu" },
        { 1135, "KuaTianQiao" },
        { 1136, "ShengRenLei" },
        { 1137, "JianFeng" },
        { 1138, "HouWeiTa" },
        { 1139, "BaiYinJiShi" },
        { 1140, "LaiShengHuiLang" },
        { 1141, "BaoFengLuMen" },
        { 1142, "YouLingHu" },
        { 1143, "ShiLvHu" },
        { 1144, "HuangHunWan" },
        { 1145, "XiaoALaMiGe" },
        { 1146, "FangLangShenLiTang" },
        { 1147, "JingJiSen" },
        { 1148, "LangYanQiu" },
        { 1149, "ShengRenLvDao" },
        { 1150, "BuHuiZhanQuan" },
        { 1151, "JiuTeng" },
        { 1152, "RongYaoXi" },
        { 1153, "JingShu" },
        { 1154, "YuMenYiXue" },
        { 1155, "YiWangLvZhou" },
        { 1156, "YanDiLing" },
        { 1157, "GeYongLieGu" },
        { 1158, "LiuShaWu" },
        { 1159, "BaJianShiQianTing" },
        { 1160, "Bahamute" },
        { 1161, "Zhushenhuanghun" },
        { 1162, "Wangzhezhijian" },
        { 1163, "Luxingniao" },
        { 1164, "Shenshengcaipansuo" },
        { 1165, "Bingtiangong" },
        { 1166, "Longchaoshendian" },
        { 1167, "HongYuHai" },
        { 1168, "HuangJinGang" },
        { 1169, "YanXia" },
        { 1170, "ChaoFengTing" },
        { 1171, "ShenQuanHen" },
        { 1172, "BaiYinXiang" },
        { 1173, "YuZhouHeYin" },
        { 1174, "WoXianXiRan" },
        { 1175, "ChenXiWangZuo" },
        { 1176, "MengYuBaoJing" },
        { 1177, "HaiMaoChaWu" },
        { 1178, "RouFengHaiWan" },
        { 1179, "HuPoYuan" },

        { 2048, "Unei" },
        { 2049, "Doga" },
        { 2050, "KrBahamut" },
        { 2051, "KrIfrit" },
        { 2052, "KrGaruda" },
        { 2053, "KrRamuh" },
        { 2054, "KrOdin" },
        { 2055, "KrUltima" },
        { 2056, "KrMandragora" },
        { 2057, "KrTonberry2" },
        { 2058, "KrExcalibur" },
        { 2059, "KrPhoenix" },
        { 2060, "KrAlexander" },
        { 2061, "KrTitan" },
        { 2062, "KrLeviathan" },
        { 2063, "KrShiva" },
        { 2064, "KrBehemoth" },
        { 2065, "KrGilgamesh" },
        { 2066, "KrSabotender" },
        { 2067, "KrUnicorn" },
        { 2068, "KrRagnarok" },
        { 2069, "KrRamia" },

        { 2075, "KrCarbuncle" },
        { 2076, "KrChocobo" },
        { 2077, "KrMoogle" },
        { 2078, "KrTonberry" },
        { 2079, "KrCaitsith" },
        { 2080, "KrFenrir" }
    };
}