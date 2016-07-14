using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phony.Internals.RandomTypeData
{
    internal class RandomValueSelectorGenerator<T> : RandomTypeValueGeneratorBase<T>
    {
        private readonly T[] selection;

        public RandomValueSelectorGenerator(params T[] selection)
        {
            this.selection = selection;
        }

        public override object GenerateValue()
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, selection.Count());
            return selection[randomIndex];
        }
    }
}
