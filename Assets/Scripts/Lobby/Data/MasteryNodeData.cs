
namespace MasterySystem
{
    [System.Serializable]
    public class MasteryNodeData
    {
        //현 노드의 고유 값이다 
        public uint id;
        /// <summary>
        /// 활성화가 가능한지의 여부를 가리킨다
        /// </summary>
        public bool canactivate;
        /// <summary>
        /// 사용중인지 여부를 알려준다
        /// </summary>
        public bool use;
        /// <summary>
        /// 다음 노드의 포인터이다. 현 노드가활성화 되면 다음 노드의 활성화 
        /// 가능여부가 활성화된다.
        /// </summary>
        public MasteryNodeData next;
        /// <summary>
        /// Lock의 구매비용이다.
        /// </summary>
        public uint cost;

        public uint rankFloor;

        /// <summary>
        /// 스킬 키값 TableStatSkill 참조
        /// </summary>
        public string skillKey;

        public MasteryNodeData(JosnMasteryData data)
        {
            this.id = data.id;
            this.canactivate = data.canactivate >= 1 ? true : false;
            this.rankFloor = data.rankFloor;
            this.cost = data.cost;
            this.skillKey = data.statSkill;
        }
    }
}