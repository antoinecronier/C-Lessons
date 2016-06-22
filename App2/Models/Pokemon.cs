using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Models
{

    public class AbilityItem : EntityBase
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        private string url;
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.OnPropertyChanged("Url");
            }
        }
    }

    public class Ability : EntityBase
    {
        private bool is_hidden;
        public bool Is_hidden
        {
            get
            {
                return this.is_hidden;
            }
            set
            {
                this.is_hidden = value;
                this.OnPropertyChanged("Is_hidden");
            }
        }

        private int slot;
        public int Slot
        {
            get
            {
                return this.slot;
            }
            set
            {
                this.slot = value;
                this.OnPropertyChanged("Slot");
            }
        }

        private AbilityItem abilityItem;
        public AbilityItem AbilityItem
        {
            get
            {
                return this.abilityItem;
            }
            set
            {
                this.abilityItem = value;
                this.OnPropertyChanged("AbilityItem");
            }
        }
    }

    public class Form : EntityBase
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        private string url;
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.OnPropertyChanged("Url");
            }
        }
    }

    public class Version : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class GameIndice : EntityBase
    {
        public int game_index { get; set; }
        public Version version { get; set; }
    }

    public class MoveItem : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionGroup : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MoveLearnMethod : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionGroupDetail : EntityBase
    {
        public int level_learned_at { get; set; }
        public VersionGroup version_group { get; set; }
        public MoveLearnMethod move_learn_method { get; set; }
    }

    public class Move : EntityBase
    {
        public MoveItem move { get; set; }
        public List<VersionGroupDetail> version_group_details { get; set; }
    }

    public class Species : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class StatItem : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Stat : EntityBase
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public StatItem stat { get; set; }
    }

    public class TypeItem : EntityBase
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Type : EntityBase
    {
        public int slot { get; set; }
        public TypeItem type { get; set; }
    }

    public class Pokemon : EntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public List<Ability> abilities { get; set; }
        public List<Form> forms { get; set; }
        public List<GameIndice> game_indices { get; set; }
        public List<Move> moves { get; set; }
        public Species species { get; set; }
        public List<Stat> stats { get; set; }
        public List<Type> types { get; set; }
    }

}
