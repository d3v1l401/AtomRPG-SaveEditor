﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using AtomSaveEditor.Atom.GeneralSave;
//
//    var save = Save.FromJson(jsonString);

namespace AtomSaveEditor.Atom.GeneralSave
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using AtomSaveEditor.Atom.PlayerSave;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Save
    {
        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("relationship")]
        public Relationship Relationship { get; set; }

        [JsonProperty("worldTime")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long WorldTime { get; set; }

        [JsonProperty("notebook")]
        public string[] Notebook { get; set; }

        [JsonProperty("quest")]
        public Quest Quest { get; set; }

        [JsonProperty("worldmap")]
        public string[] Worldmap { get; set; }

        [JsonProperty("battleExp")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long BattleExp { get; set; }

        [JsonProperty("player_ava")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long PlayerAva { get; set; }

        [JsonProperty("player_name")]
        public string PlayerName { get; set; }

        [JsonProperty("player_bio")]
        public string PlayerBio { get; set; }

        [JsonProperty("worldmap_id")]
        public string WorldmapId { get; set; }

        [JsonProperty("worldPos_x")]
        public string WorldPosX { get; set; }

        [JsonProperty("worldPos_y")]
        public string WorldPosY { get; set; }

        [JsonProperty("battle")]
        public Battle Battle { get; set; }

        [JsonProperty("difficult")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Difficult { get; set; }

        [JsonProperty("save_version")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long SaveVersion { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }

    public partial class Battle
    {
        [JsonProperty("inbattle")]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public bool Inbattle { get; set; }
    }

    public partial class Quest
    {
        [JsonProperty("MAIN.MAROZOV")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MainMarozov { get; set; }

        [JsonProperty("MAIN.FIDEL")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MainFidel { get; set; }

        [JsonProperty("MAIN.FIND_BUNKER")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MainFindBunker { get; set; }

        [JsonProperty("VILLAGE.BARMAN.BOOK")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageBarmanBook { get; set; }

        [JsonProperty("VILLAGE.BAROWNER.AMANITA")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageBarownerAmanita { get; set; }

        [JsonProperty("VILLAGE.PUMP.ENGINE")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillagePumpEngine { get; set; }

        [JsonProperty("VILLAGE.TRADER.ALEX")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageTraderAlex { get; set; }

        [JsonProperty("VILLAGE.MAYOR.INFORMER")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageMayorInformer { get; set; }

        [JsonProperty("VILLAGE.KILL.INFORMER")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageKillInformer { get; set; }

        [JsonProperty("VILLAGE.SPY.AGENT")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageSpyAgent { get; set; }

        [JsonProperty("FACTORY.GANG.FIRSTWORK")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FactoryGangFirstwork { get; set; }

        [JsonProperty("FACTORY.SICK.HELP")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FactorySickHelp { get; set; }

        [JsonProperty("MOONSHINERS.SAMSON.FIND")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MoonshinersSamsonFind { get; set; }

        [JsonProperty("FACTORY.GANG.WORK1")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FactoryGangWork1 { get; set; }

        [JsonProperty("FACTORY.GANG.WORK1.DONE")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FactoryGangWork1Done { get; set; }

        [JsonProperty("MOONSHINERS.PROTECT")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MoonshinersProtect { get; set; }

        [JsonProperty("VILLAGE.WALLGUARD.BEAR")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageWallguardBear { get; set; }

        [JsonProperty("MOONSHINERS.PETROVICH")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MoonshinersPetrovich { get; set; }

        [JsonProperty("MOONSHINERS.END")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MoonshinersEnd { get; set; }

        [JsonProperty("RAT.FOREST.FIND")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long RatForestFind { get; set; }

        [JsonProperty("CITY.STRATEG1")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CityStrateg1 { get; set; }

        [JsonProperty("CITY.STRATEG2")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CityStrateg2 { get; set; }

        [JsonProperty("CITY.STRATEG3")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CityStrateg3 { get; set; }

        [JsonProperty("CULT_OBSERVER")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CultObserver { get; set; }

        [JsonProperty("VILLAGE.BARMAN.BOOK_END")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long VillageBarmanBookEnd { get; set; }

        [JsonProperty("CITY.BOOK")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CityBook { get; set; }

        [JsonProperty("CITY.SICK")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CitySick { get; set; }

        [JsonProperty("CITY.POPOV")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long CityPopov { get; set; }
    }

    public partial class Relationship
    {
        [JsonProperty("relationMap")]
        public RelationMap[] RelationMap { get; set; }
    }

    public partial class RelationMap
    {
        [JsonProperty("fractionA")]
        public string FractionA { get; set; }

        [JsonProperty("fractionB")]
        public string FractionB { get; set; }

        [JsonProperty("value")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Value { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("level")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Level { get; set; }

        [JsonProperty("xp")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Xp { get; set; }

        [JsonProperty("strength")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Strength { get; set; }

        [JsonProperty("perception")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Perception { get; set; }

        [JsonProperty("endurance")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Endurance { get; set; }

        [JsonProperty("charisma")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Charisma { get; set; }

        [JsonProperty("intelligence")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Intelligence { get; set; }

        [JsonProperty("agility")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Agility { get; set; }

        [JsonProperty("luck")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Luck { get; set; }

        [JsonProperty("skills")]
        public Skills Skills { get; set; }

        [JsonProperty("perks")]
        public string[] Perks { get; set; }

        [JsonProperty("freeSkillPoints")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FreeSkillPoints { get; set; }

        [JsonProperty("freeStatPoints")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FreeStatPoints { get; set; }

        [JsonProperty("freeSpecPoints")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FreeSpecPoints { get; set; }

        [JsonProperty("specLevel")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long SpecLevel { get; set; }

        public static explicit operator Stats(Atom.PlayerSave.Stats v)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Skills
    {
        [JsonProperty("SmallGuns")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long SmallGuns { get; set; }

        [JsonProperty("BigGuns")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long BigGuns { get; set; }

        [JsonProperty("AutomaticFirearms")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long AutomaticFirearms { get; set; }

        [JsonProperty("Unarmed")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Unarmed { get; set; }

        [JsonProperty("MeleeWeapons")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long MeleeWeapons { get; set; }

        [JsonProperty("Throwing")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Throwing { get; set; }

        [JsonProperty("FirstAid")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long FirstAid { get; set; }

        [JsonProperty("Crafting")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Crafting { get; set; }

        [JsonProperty("Sneak")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Sneak { get; set; }

        [JsonProperty("Lockpick")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Lockpick { get; set; }

        [JsonProperty("Steal")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Steal { get; set; }

        [JsonProperty("Alertness")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Alertness { get; set; }

        [JsonProperty("Science")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Science { get; set; }

        [JsonProperty("Speech")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Speech { get; set; }

        [JsonProperty("Barter")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Barter { get; set; }

        [JsonProperty("Gambling")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Gambling { get; set; }

        [JsonProperty("Outdoorsman")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long Outdoorsman { get; set; }
    }

    public partial class Save
    {
        public static Save FromJson(string json) => JsonConvert.DeserializeObject<Save>(json, AtomSaveEditor.Atom.GeneralSave.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Save self) => JsonConvert.SerializeObject(self, AtomSaveEditor.Atom.GeneralSave.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PurpleParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }
            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
            return;
        }

        public static readonly PurpleParseStringConverter Singleton = new PurpleParseStringConverter();
    }

    internal class FluffyParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly FluffyParseStringConverter Singleton = new FluffyParseStringConverter();
    }
}
