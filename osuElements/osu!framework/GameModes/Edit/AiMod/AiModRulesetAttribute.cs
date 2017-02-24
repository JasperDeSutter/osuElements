using System;
using System.Reflection;

namespace osu.GameModes.Edit.AiMod
{
    public class LoadAssemblyAttributesProxy : MarshalByRefObject
    {
        public LoadAssemblyAttributesProxy()
        {

        }
        public AiModRulesetAttribute[] LoadAssemblyAttributes(string assFile)
        {
            Assembly asm = Assembly.LoadFrom(assFile);
            AiModRulesetAttribute[] plugInAttribute = asm.GetCustomAttributes(typeof(AiModRulesetAttribute), false) as AiModRulesetAttribute[];
            return plugInAttribute;
        }
    }

    [Serializable]
    [AttributeUsageAttribute(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    sealed public class AiModRulesetAttribute : Attribute
    {
        public string RulesetName { get; private set; }
        public string EntryType { get; private set; }

        public AiModRulesetAttribute(string pluginName, string entryType)
        {
            RulesetName = pluginName;
            EntryType = entryType;
        }
    }
}
