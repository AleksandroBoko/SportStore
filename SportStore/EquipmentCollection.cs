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


        /// <summary>Adding an equipment to the end of the collection</summary>        
        public void Add(BaseEquipment eq)
        {
            IncreaseSize();
            equipments[equipments.Length - 1] = eq;
        }

        /// <summary>Removing all equipments from the collection</summary>
        public void RemoveAll()
        {
            equipments = new BaseEquipment[] { };
        }

        /// <summary>Removing equipment from the collection by the name</summary>
        public bool RemoveByName(string val)
        {
            int LengthBeforeRemoving = Length;

            if (IsExistEquipment(val))
            {
                if (Length == 1)
                    RemoveAll();
                else
                    equipments = CopyValuesForDecrease(val);
            }

            return LengthBeforeRemoving != Length;
        }

        /// <summary>Removing equipment from the collection by the index</summary>
        public bool RemoveByIndex(int index)
        {
            int LengthBeforeRemoving = Length;

            if (IsExistEquipment(index))
            {
                if (Length == 1)
                    RemoveAll();
                else
                    equipments = CopyValuesForDecrease(index);
            }


            return LengthBeforeRemoving != Length;
        }

        /// <summary>Getting equipment from the collection by the index</summary>
        public BaseEquipment GetEquipmentByIndex(int index)
        {
            if (Length == 0)
                return null;

            if (index < 0 || index > Length)
                return null;
            else
                return equipments[index];
        }

        /// <summary>Getting equipment from the collection by the name</summary>
        public BaseEquipment GetEquipmentByName(string name)
        {
            if (Length == 0)
                return null;

            BaseEquipment result = null;
            foreach (BaseEquipment eq in equipments)
            {
                if (eq.Name == name)
                {
                    result = eq;
                    break;
                }
            }

            return result;
        }

        /// <summary>Checking equipment by the name</summary>
        private bool IsExistEquipment(string name)
        {
            bool result = false;
            foreach (BaseEquipment eq in equipments)
            {
                if (eq.Name == name)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>Checking equipment by the index</summary>
        private bool IsExistEquipment(int index)
        {
            if (index < 0 || index > (Length - 1))
                return false;
            else
                return true;
        }

        /// <summary>Increase the size of the array</summary>
        private void IncreaseSize()
        {
            if (equipments == null)
                equipments = new BaseEquipment[1];
            else
                equipments = CopyValuesForIncrease();
        }

        /// <summary>Copy elements to increase the array</summary>
        private BaseEquipment[] CopyValuesForIncrease()
        {
            BaseEquipment[] result = new BaseEquipment[equipments.Length + 1];
            for (int i = 0; i < equipments.Length; i++)
            {
                result[i] = equipments[i];
            }

            return result;
        }

        /// <summary>Copy elements to decrease the array usinng string variable 'name'</summary>
        private BaseEquipment[] CopyValuesForDecrease(string name)
        {
            BaseEquipment[] result = new BaseEquipment[equipments.Length - 1];

            int index = 0;
            bool found = false;

            for (int i = 0; i < equipments.Length; i++)
            {
                if (equipments[i].Name == name && !found)
                {
                    found = true;
                    continue;
                }

                result[index] = equipments[i];
                index++;
            }

            return result;
        }

        /// <summary>Copy elements to decrease the array usinng integer variable 'index'</summary>
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

        public void SetElementByIndex(int index, BaseEquipment bq)
        {
            if(0 <= index && index < Length )
            {
                equipments[index] = bq;
            }
        }
    }
}
