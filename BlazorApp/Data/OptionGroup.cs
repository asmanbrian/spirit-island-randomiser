using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
namespace SiRandomizer.Data
{
    [JsonConverter(typeof(OptionGroupConverter))]
    public class OptionGroup<T> : SelectableComponentBase<T>, IComponentCollection<T>
        where T : SelectableComponentBase<T>
    {
        /// <summary>
        /// The child components that are in this group.
        /// The key is the name of the component.
        /// </summary>
        /// <value></value>
        private Dictionary<string, T> _children = new Dictionary<string, T>(); 

        [JsonIgnore]
        public T this[string name] 
        {
            get 
            {
                return _children[name];
            }
            set
            {
                Add(value);
            }
        }

        public OptionGroup() 
        {
            PropertyChanged += ThisUpdated;
        }

        public void Add(T entry)
        {
            _children.Add(entry.Name, entry);
            entry.PropertyChanged += ChildUpdated;
        }
        
        public void ChildUpdated (object sender, PropertyChangedEventArgs args) {
            // When child is updated, trigger the property changed
            // event on the group.
            OnPropertyChanged("Child_" + args.PropertyName);
        }

        public void ThisUpdated (object sender, PropertyChangedEventArgs args) {
            // When the selection state of this group is changed, 
            // update all children accordingly.
            if(args.PropertyName == nameof(Selected)) 
            {
                foreach(var child in _children.Values)
                {
                    child.Selected = Selected;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children.Values.GetEnumerator();
        }

        public override bool IsVisible(OverallConfiguration config)
        {
            return true;
        }
    }
}
