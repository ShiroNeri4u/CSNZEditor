﻿
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;



namespace CSODataCore
{
    /// <summary>
    /// Id搜索模式
    /// </summary>
    public enum SearchMode : byte
    {
        None = 0,
        Reinforce = 1,
        Paint = 2,
    }
    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemCategory : byte
    {
        /// <summary>
        /// 副武器
        /// </summary>
        Pistol = 1,
        /// <summary>
        /// 霞弹枪
        /// </summary>
        ShotGun = 2,
        /// <summary>
        /// 冲锋枪
        /// </summary>
        SubMachineGun = 3,
        /// <summary>
        /// 步枪
        /// </summary>
        Rifle = 4,
        /// <summary>
        /// 机枪
        /// </summary>
        MachineGun = 5,
        /// <summary>
        /// 装备
        /// </summary>
        Equipment = 6,
        /// <summary>
        /// 角色
        /// </summary>
        Character = 7,
        /// <summary>
        /// 不消耗型道具
        /// </summary>
        UnconsumableItem = 8,
        /// <summary>
        /// 消耗型道具
        /// </summary>
        ConsumableItem = 9,
        /// <summary>
        /// 近身装备
        /// </summary>
        Knife = 11,
        /// <summary>
        /// 饰品
        /// </summary>
        Costume = 12,
        /// <summary>
        /// 武器配件
        /// </summary>
        WeaponPart = 13
    }

    /// <summary>
    /// 使用的阵营
    /// </summary>
    public enum ItemTeam : byte
    {
        /// <summary>
        /// 全阵营
        /// </summary>
        All = 0,
        /// <summary>
        /// T阵营
        /// </summary>
        Terror = 1,
        /// <summary>
        /// CT阵营
        /// </summary>
        CounterTerror = 2,
    }

    /// <summary>
    /// 物品索引
    /// </summary>
    public enum ItemSortingIndex
    {
        /// <summary>
        /// 补给箱武器
        /// </summary>
        BoxWeapon = 0,
        /// <summary>
        /// 冲锋枪
        /// </summary>
        SubMachineGun = 1,
        /// <summary>
        /// 霞弹枪
        /// </summary>
        ShotGun = 2,
        /// <summary>
        /// 突击步枪
        /// </summary>
        AssaultRifle = 3,
        /// <summary>
        /// 狙击步枪
        /// </summary>
        Rifle = 4,
        /// <summary>
        /// 机关枪
        /// </summary>
        MachineGun = 5,
        /// <summary>
        /// 副武器
        /// </summary>
        Pistol = 7,
        /// <summary>
        /// 近身装备
        /// </summary>
        Knife = 8,
        /// <summary>
        /// 装备类武器
        /// </summary>
        Special = 9,
        /// <summary>
        /// T阵营角色
        /// </summary>
        TerrorCharacter = 1000,
        /// <summary>
        /// CT阵营角色
        /// </summary>
        CounterTerrorCharacter = 1001,
        /// <summary>
        /// 头部饰品
        /// </summary>
        HeadCostume = 1100,
        /// <summary>
        /// 背部饰品
        /// </summary>
        BackCostume = 1101,
        /// <summary>
        /// 腰部饰品
        /// </summary>
        PelvisCostume = 1102,
        /// <summary>
        /// 手臂饰品
        /// </summary>
        ArmCostume = 1103,
        /// <summary>
        /// 纹身
        /// </summary>
        Tatto = 1104,
        /// <summary>
        /// 宠物饰品
        /// </summary>
        PetCostume = 1105,
        /// <summary>
        /// 破译芯片
        /// </summary>
        CashDecoder = 2000,
        /// <summary>
        /// 集字活动
        /// </summary>
        EventItem = 2001,
        /// <summary>
        /// 喷漆
        /// </summary>
        Periodic = 2002,
        /// <summary>
        /// 武器皮肤(未实装？)
        /// </summary>
        Skin = 2003,
        /// <summary>
        /// 武器涂装
        /// </summary>
        WeaponPaint = 2004,
        /// <summary>
        /// 武器配件
        /// </summary>
        WeaponPart = 2005,
        /// <summary>
        /// 复活特效
        /// </summary>
        RespawnEffect = 2006,
        /// <summary>
        /// 伤害文字样式
        /// </summary>
        DamageFontSkin = 2007,
        /// <summary>
        /// 原声轨带
        /// </summary>
        Soundtrack = 2008,
        /// <summary>
        /// 普通强化材料
        /// </summary>
        NormalReinforceMaterial = 2100,
        /// <summary>
        /// 高级强化材料
        /// </summary>
        AdvancedReinforceMaterial = 2101,
        /// <summary>
        /// 单一属性强化材料碎片
        /// </summary>
        SingleAttributeReinforceMaterialPart = 2102,
        /// <summary>
        /// 单一属性强化材料
        /// </summary>
        SingleAttributeReinforceMaterial = 2103,
        /// <summary>
        /// 还原强化材料
        /// </summary>
        ResetReinforceResetMaterial = 2104,
        /// <summary>
        /// 单一属性还原强化材料
        /// </summary>
        AntiSingleAttributeReinforceResetMaterial = 2106,
        /// <summary>
        /// 道具延长卷
        /// </summary>
        ItemExtend = 2200,
        /// <summary>
        /// 等级奖励宝箱
        /// </summary>
        LevelGiftBox = 2201,
        /// <summary>
        /// 加成类道具
        /// </summary>
        PointUpItem = 2202,
        /// <summary>
        /// 普通类道具
        /// </summary>
        NormalItem = 2203,
        /// <summary>
        /// 转让类道具
        /// </summary>
        GiftItem = 2204,
        /// <summary>
        /// 探索活动道具
        /// </summary>
        ExpeditionEventItem = 2205,
        /// <summary>
        /// 竞技模式道具
        /// </summary>
        CompetitiveModeItem = 3000,
        /// <summary>
        /// 生化僵尸
        /// </summary>
        ZombieCharacter = 3100,
        /// <summary>
        /// 生活僵尸皮肤
        /// </summary>
        ZombieSkinCostume = 3101,
        /// <summary>
        /// 生化道具(已移除)
        /// </summary>
        ZombieModeItem = 3102,
        /// <summary>
        /// 大灾变配件
        /// </summary>
        ScenPart = 3200,
        /// <summary>
        /// 大灾变掉落道具
        /// </summary>
        ScenDorpItem = 3201,
        /// <summary>
        /// 大灾变加成道具
        /// </summary>
        ScenPonitUpItem = 3202,
        /// <summary>
        /// 大灾变钥匙
        /// </summary>
        ScenKey = 3203,
        /// <summary>
        /// 大灾变配件盒子
        /// </summary>
        ScenePartBox = 3204,
        /// <summary>
        /// 缔造者奖杯
        /// </summary>
        CreatorTrophy = 3300,
        /// <summary>
        /// 缔造者使用协议
        /// </summary>
        CreatorLicense = 3301,
        /// <summary>
        /// 缔造者道具
        /// </summary>
        CreatorItem = 3302,
    }

    /// <summary>
    /// 物品评级
    /// </summary>
    public enum ItemGrade : byte
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// 普通
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 优秀
        /// </summary>
        Excellent = 2,
        /// <summary>
        /// 精良
        /// </summary>
        Refined = 3,
        /// <summary>
        /// 稀有
        /// </summary>
        Rare = 4,
        /// <summary>
        /// 超凡
        /// </summary>
        Epic = 5,
        /// <summary>
        /// 传奇
        /// </summary>
        Legendary = 6,
        /// <summary>
        /// 特别(目前只有2个喷漆)
        /// </summary>
        Special = 7,
    }

    /// <summary>
    /// 武器不同模式的评级
    /// </summary>
    public enum ItemGradeMode : byte
    {
        /// <summary>
        /// 较差
        /// </summary>
        Poor = 0,
        /// <summary>
        /// 尚可
        /// </summary>
        Acceptable = 1,
        /// <summary>
        /// 普通
        /// </summary>
        Normal = 2,
        /// <summary>
        /// 良好
        /// </summary>
        Good = 3,
        /// <summary>
        /// 优秀
        /// </summary>
        Excellent = 4,
        /// <summary>
        /// 超强
        /// </summary>
        Extraordinary = 5,
        /// <summary>
        /// 至高
        /// </summary>
        Ultimate = 6,
    }

    /// <summary>
    /// 武器配件类型
    /// </summary>
    public enum WeaponPart : byte
    {
        /// <summary>
        /// 不开放配件
        /// </summary>
        Disable = 0,
        /// <summary>
        /// 主副武器开放配件
        /// </summary>
        WeaponType = 3,
        /// <summary>
        /// 近身武器开放配件
        /// </summary>
        KnifeType = 5,
        /// <summary>
        /// 装备类武器开放配件
        /// </summary>
        SpecialType = 9,
    }

    public sealed class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Map(m => m.Id).Index(1);
            Map(m => m.Id).Index(0);
            Map(m => m.RecourceName).Index(2);
            Map(m => m.Category).Index(4);
            Map(m => m.Team).Index(7);
            Map(m => m.Period).Index(27);
            Map(m => m.InGameItem).Index(35);
            Map(m => m.SortingIndex).Index(46);
            Map(m => m.ItemGrade).Index(47);
        }
    }

    public class Item
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 翻译文本
        /// </summary>
        public string? TransName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 物品Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 资源Id
        /// </summary>
        public string? RecourceName { get; set; }
        /// <summary>
        /// 物品类型
        /// </summary>
        public ItemCategory Category { get; set; }
        /// <summary>
        /// 使用阵营
        /// </summary>
        public ItemTeam Team { get; set; }
        /// <summary>
        /// 装备数据
        /// </summary>
        public WeaponInfomation? WeaponInfomation { get; set; }
        /// <summary>
        /// 是否是期限制道具
        /// </summary>
        public bool Period { get; set; }
        /// <summary>
        /// 是否是游戏内的物品
        /// </summary>
        public bool InGameItem { get; set; }
        /// <summary>
        /// 物品索引
        /// </summary>
        public ItemSortingIndex SortingIndex { get; set; }
        /// <summary>
        /// 物品评级
        /// </summary>
        public ItemGrade? ItemGrade { get; set; }
        /// <summary>
        /// 武器强化数据
        /// </summary>
        public Reinforce? Reinforce { get; set; }
        /// <summary>
        /// 武器涂装
        /// </summary>
        public int[]? Paints { get; set; }

    }

    public sealed class WeaponInfomationMap : ClassMap<WeaponInfomation>
    {
        public WeaponInfomationMap()
        {
            Map(m => m.Damage).Index(21).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.HitRate).Index(22).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.Reaction).Index(23).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.FiringSpeed).Index(24).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.Weight).Index(25).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.ItemGradeMode).Index(48).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.ZomibeDamage).Index(49).TypeConverter<CostomConverter<int[]>>();
            Map(m => m.ScenDamage).Index(50).TypeConverter<CostomConverter<int[]>>();
            Map(m => m.KnockBack).Index(51).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.Delay).Index(52).TypeConverter<CostomConverter<byte[]>>();
            Map(m => m.WeaponPart).Index(54);
        }
    }

    /// <summary>
    /// 装备数据
    /// </summary>
    public class WeaponInfomation
    {
        /// <summary>
        /// 普通模式伤害
        /// </summary>
        public byte[]? Damage { get; set; }
        /// <summary>
        /// 精准度
        /// </summary>
        public byte[]? HitRate { get; set; }
        /// <summary>
        /// 稳定性
        /// </summary>
        public byte[]? Reaction { get; set; }
        /// <summary>
        /// 连射性
        /// </summary>
        public byte[]? FiringSpeed { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public byte[]? Weight { get; set; }
        /// <summary>
        /// 生化模式伤害
        /// </summary>
        public int[]? ZomibeDamage { get; set; }
        /// <summary>
        /// 大灾变模式伤害
        /// </summary>
        public int[]? ScenDamage { get; set; }
        /// <summary>
        /// 击退
        /// </summary>
        public byte[]? KnockBack { get; set; }
        /// <summary>
        /// 定身
        /// </summary>
        public byte[]? Delay { get; set; }
        /// <summary>
        /// 武器不同模式评级
        /// </summary>
        public ItemGradeMode[]? ItemGradeMode { get; set; }
        /// <summary>
        /// 武器配件类型
        /// </summary>
        public WeaponPart WeaponPart { get; set; }
    }
    public sealed class ReinforceMap : ClassMap<Reinforce>
    {
        public ReinforceMap()
        {
            Map(m => m.TotalMaxLv).Index(1);
            Map(m => m.Damage).Index(2);
            Map(m => m.Accuracy).Index(3);
            Map(m => m.KickBack).Index(4);
            Map(m => m.Wegiht).Index(5);
            Map(m => m.FireRate).Index(6);
            Map(m => m.Ammo).Index(7);
            Map(m => m.OverDmg).Index(8);
        }
    }
    /// <summary>
    /// 武器强化数据
    /// </summary>
    public class Reinforce
    {
        /// <summary>
        /// 最高强化等级
        /// </summary>
        public byte TotalMaxLv { get; set; }
        /// <summary>
        /// 伤害
        /// </summary>
        public byte Damage { get; set; }
        /// <summary>
        /// 精确度
        /// </summary>
        public byte Accuracy { get; set; }
        /// <summary>
        /// 后坐力
        /// </summary>
        public byte KickBack { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public byte Wegiht { get; set; }
        /// <summary>
        /// 射速
        /// </summary>
        public byte FireRate { get; set; }
        /// <summary>
        /// 填弹数
        /// </summary>
        public byte Ammo { get; set; }
        /// <summary>
        /// +9终极提升类型
        /// </summary>
        public byte? OverDmg { get; set; }
    }

    public class PaintJson
    {
        public byte Verion { get; set; }
        public required Dictionary<int, int[]> PaintInfos { get; set; }
    }

    public class CostomConverter<T> : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text != null && text != "")
            {
                string[] data = text.Split(',');
                if (typeof(T) == typeof(byte[]))
                {
                    byte[] bytes = new byte[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        bytes[i] = byte.Parse(data[i]);
                    }
                    return bytes;
                }
                else if (typeof(T) == typeof(int[]))
                {
                    int[] ints = new int[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        ints[i] = int.Parse(data[i]);
                    }
                    return ints;
                }
                else return data;
            }
            else
            {
                if (typeof(T) == typeof(byte[]))
                {
                    return Array.Empty<byte>();
                }
                else if (typeof(T) == typeof(int[]))
                {
                    return Array.Empty<int>();
                }
                else
                {
                    return Array.Empty<string>();
                }

            }
        }
    }

    public static partial class ItemManager
    {
        private const string PreName = "CSO_Item_Name_";
        private const string PreDesc = "CSO_Item_Desc_";
        private static readonly Dictionary<int, Item> ItemDictionary = [];
        private static readonly Dictionary<string, List<int>> StringToId = [];
        private static readonly Dictionary<int, List<Item>> PaintDictionary = [];
        private static readonly Dictionary<int, Item> ReinforceDictionary = [];
        private static readonly Dictionary<ItemGrade, List<Item>> ItemGradeDictionary = new()
        {
            { ItemGrade.None, new List<Item>() },
            { ItemGrade.Normal, new List<Item>() },
            { ItemGrade.Excellent, new List<Item>() },
            { ItemGrade.Refined, new List<Item>() },
            { ItemGrade.Rare, new List<Item>() },
            { ItemGrade.Epic, new List<Item>() },
            { ItemGrade.Legendary, new List<Item>() },
            { ItemGrade.Special, new List<Item>() },
        };
        private static readonly Dictionary<string, string> LanguageDictionary = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 导入item.csv路径 <see cref="string"/> 的值
        /// </summary>
        /// <param name="filePath"></param>
        public static void ImportItem(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                AllowComments = true,
                Comment = ';',
                IgnoreBlankLines = true,
                IgnoreReferences = true,
            };
            using StreamReader reader = new(filePath);
            using CsvReader csv = new(reader, config);
            {
                csv.Context.TypeConverterCache.AddConverter<byte[]>(new CostomConverter<byte[]>());
                csv.Context.TypeConverterCache.AddConverter<int[]>(new CostomConverter<int[]>());
                csv.Context.RegisterClassMap<ItemMap>();
                csv.Context.RegisterClassMap<WeaponInfomationMap>();

                while (csv.Read())
                {
                    Item item = csv.GetRecord<Item>();
                    if ((int)item.SortingIndex < 10)
                    {
                        item.WeaponInfomation = csv.GetRecord<WeaponInfomation>();
                    }
                    ItemDictionary.Add(item.Id, item);
                    if (item.Name != null)
                    {
                        List<int> indexList = [item.Id];
                        if(!StringToId.TryAdd(item.Name, indexList))
                        {
                            if (!StringToId[item.Name].Contains(item.Id))
                            {
                                StringToId[item.Name].Add(item.Id);
                            }
                        }
                    }
                    if (item.ItemGrade != null)
                    {
                        byte num = (byte)item.ItemGrade;
                        ItemGradeDictionary[(ItemGrade)num].Add(item);
                    }
                }
            }
        }
        /// <summary>
        /// 导入ReinforceMaxLv.csv路径 <see cref="string"/> 的值
        /// </summary>
        /// <param name="filePath"></param>
        public static void ImportReinforce(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                AllowComments = true,
                Comment = ';',
                IgnoreBlankLines = true,
                IgnoreReferences = true,
            };
            using StreamReader reader = new(filePath);
            using CsvReader csv = new(reader, config);
            {
                csv.Context.RegisterClassMap<ReinforceMap>();
                while (csv.Read())
                {
                    int id = csv.GetField<int>(0);
                    if (ItemDictionary[id] != null)
                    {
                        ItemDictionary[id].Reinforce = csv.GetRecord<Reinforce>();
                        ReinforceDictionary.Add(id, ItemDictionary[id]);
                    }
                }
            }
        }
        public static void ImportPaints(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var paintJson = JsonSerializer.Deserialize<PaintJson>(jsonString);
        }

        public static void ImportLanguage(string filePath)
        {
            using StreamReader reader = new(filePath);
            {
                List<string> Lines = [];
                int count = -1;
                while (!reader.EndOfStream)
                {
                    var text = reader.ReadLine();
                    if (text != null && text != "" && !text.StartsWith('"') && !text.StartsWith('{') && !text.StartsWith('}') && !text.StartsWith('/'))
                    {
                        Lines[count] = Lines[count] + "\\n" + text;
                    }
                    else
                    {
                        if (text != null)
                        {
                            Lines.Add(text);
                            count++;
                        }
                    }
                }

                foreach (string line in Lines)
                {
                    var text = line.Trim();
                    if (string.IsNullOrEmpty(text) || line.StartsWith("//"))
                        continue;
                    Regex regex = Filter();

                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        string key = match.Groups["key"].Value;
                        string value = match.Groups["value"].Value;

                        LanguageDictionary[key] = value;
                    }
                }
            }
        }

        public static void LoadLanguage()
        {
            Dictionary<string, string> trans = LanguageDictionary;
            Dictionary<int, Item> items = ItemDictionary;
            foreach (Item item in items.Values)
            {
                string name = PreName + item.RecourceName;
                string desc = PreDesc + item.RecourceName;
                if (trans.TryGetValue(name, out var _name))
                {
                    List<int> index = [item.Id];
                    item.TransName = _name;
                    if (!StringToId.TryAdd(_name, index))
                    {
                        if (!StringToId[_name].Contains(item.Id))
                        {
                            StringToId[_name].Add(item.Id);
                        }
                    }
                }
                if (trans.TryGetValue(desc, out var _desc))
                {
                    List<int> index = [item.Id];
                    item.Description = _desc;
                    if (!StringToId.TryAdd(_desc, index))
                    {
                        if (!StringToId[_desc].Contains(item.Id))
                        {
                            StringToId[_desc].Add(item.Id);
                        }
                    }
                }
            }
        }

        public static Item[] Search(string context)
        {
            Dictionary<Item, int> dictionary = [];
            foreach (string key in StringToId.Keys)
            {
                if (key.Contains(context))
                {
                    foreach (int id in StringToId[key])
                    {
                        dictionary.TryAdd(ItemDictionary[id], id);
                    }
                }
            }
            Item [] result = new Item[dictionary.Count];
            dictionary.Keys.CopyTo(result, 0);
            return result;
        }

        public static Item[] Search(ItemGrade grade)
        {
            Item[] result = [.. ItemGradeDictionary[grade]];
            return result;
        }

        public static Item[] Seacrh(int id)
        {
            return [ItemDictionary[id]];
        }

        public static Item[] Search(SearchMode mode)
        {
            if (mode == SearchMode.Reinforce)
            {
                Item[] result = new Item[ReinforceDictionary.Count];
                ReinforceDictionary.Values.CopyTo(result, 0);
                return result;
            }
            else return [];
        }

        public static Item[] Search(int id, SearchMode mode)
        {
            if (mode == SearchMode.Paint)
            {
                return [.. PaintDictionary[id]];
            }
            else if (mode == SearchMode.Reinforce)
            {
                Item[] result = new Item[ReinforceDictionary.Count];
                ReinforceDictionary.Values.CopyTo(result, 0);
                return result;
            }
            else return [ItemDictionary[id]];
        }

        [GeneratedRegex(@"^""(?<key>[^""]+)""\s+""(?<value>[^""]+)""$")]
        private static partial Regex Filter();
    }

}