namespace Gateways.Model
{
    public class BaseResultModel
    {
        public BaseResultModel(object data, int code = 200, string msg = "")
        {
            Code = code;
            Msg = msg;
            Data = data;
        }

        public BaseResultModel()
        {
        }

        /// <summary>
        ///     状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public string Msg { get; set; }

        public object Data { get; set; }
    }
}