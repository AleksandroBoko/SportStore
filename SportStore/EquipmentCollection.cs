using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore
{
    class EquipmentCollection
    {
        private BaseEquipment[] equipments;

        public int Length
        {
            get { return equipments.Length; }
        }

        public EquipmentCollection()
        {
            equipments = new BaseEquipment[] { };
        }


        /// <summary>
        /// Adding an equipment to the end of the collection
        /// </summary>
        /// <param name="eq">An equipment with type BaseEquipment</param>
        public void Add(BaseEquipment eq)
        {
            IncreaseSize();
            equipments[equipments.Length - 1] = eq;
        }

        public void RemoveAll()
        {
            equipments = new BaseEquipment[] { };
        }

        public void RemoveByName(string val)
        {
           if(IsExistEquipment(val))
            {
                if (Length == 1)
                    RemoveAll();
                else
                    equipments = CopyValuesForDecrease(val);
            }   
        }

        public void RemoveByIndex(int index)
        {
            if(IsExistEquipment(index))
            {
                if (Length == 1)
                    RemoveAll();
                else
                    equipments = CopyValuesForDecrease(index);
            }
        }

        public BaseEquipment GetEquipmentByIndex(int index)
        {
            if (Length == 0)
                return null;

            if (index < 0 || index > Length)
                return null;
            else
                return equipments[index];
        }

        public BaseEquipment GetEquipmentByName(string name)
        {
            if (Length == 0)
                return null;

            BaseEquipment result = null;  
            foreach(BaseEquipment eq in equipments)
            {
                if(eq.Name == name)
                {
                    result = eq;
                    break;
                }
            }

            return result;
        }

        private bool IsExistEquipment(string name)
        {
            bool result = false;
            foreach(BaseEquipment eq in equipments)
            {
                if(eq.Name == name)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool IsExistEquipment(int index)
        {
            if (index < 0 || index > (Length - 1))
                return false;
            else
                return true;
        }

        private void IncreaseSize()
        {
            if (equipments == null)
                equipments = new BaseEquipment[1];
            else
                equipments = CopyValuesForIncrease();
        }

        private BaseEquipment[] CopyValuesForIncrease()
        {
            BaseEquipment[] result = new BaseEquipment[equipments.Length + 1];
            for(int i=0; i < equipments.Length; i++)
            {
                result[i] = equipments[i];
            }

            return result;
        }

        private BaseEquipment[] CopyValuesForDecrease(string name)
        {
            BaseEquipment[] result = new BaseEquipment[equipments.Length - 1];

            int index = 0;
            bool found = false;

            for (int i = 0; i < equipments.Length; i++)
            {
                if(equipments[i].Name == name && !found)
                {
                    found = true;
                    continue;
                }

                result[index] = equipments[i];
                index++;
            }

            return result;
        }

        private BaseEquipment[] CopyValuesForDecrease(int index)
        {
            BaseEquipment[] result = new BaseEquipment[equipments.Length - 1];

            int j = 0;
            for (int i = 0; i < equipments.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                result[j] = equipments[i];
                j++;
            }

            return result;
        }
    }
}
