﻿using System.Collections.Generic;

namespace RegexNodes.Shared.NodeTypes
{
    public class OutputNode : Node
    {
        public override string Title => "Output";
        public override string NodeInfo => "The final output of your Regex. Use the 'Add Item' button to join together the outputs of multiple nodes, similar to the 'Concatenate' node.";

        public override List<INodeInput> NodeInputs
        {
            get
            {
                return new List<INodeInput> { Inputs };
            }
        }

        //protected InputProcedural Input { get; set; } = new InputProcedural() { Title = "Value" };
        protected InputCollection Inputs { get; set; } = new InputCollection(1);

        public OutputNode() { }

        public override string GetValue()
        {
            string result = "";
            foreach (var input in Inputs.Inputs)
            {
                result += input.GetValue();
            }
            CachedValue = result;
            return result;
        }
    }
}
