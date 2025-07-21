using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitoan.BLL
{
    public static class DiscHelper
    {
        private static readonly Dictionary<string, string> Descriptions = new()
        {
            ["Dominance"] = "Bạn là người quyết đoán, thích kiểm soát và định hướng kết quả. Bạn có xu hướng làm việc độc lập, tự tin và chủ động.",
            ["Influence"] = "Bạn là người truyền cảm hứng, thân thiện và nhiệt huyết. Bạn yêu thích giao tiếp, kết nối và thường được mọi người yêu mến.",
            ["Steadiness"] = "Bạn là người kiên định, hỗ trợ và trung thành. Bạn coi trọng sự ổn định, thích giúp đỡ người khác và tránh mâu thuẫn.",
            ["Conscientiousness"] = "Bạn là người tỉ mỉ, chính xác và có trách nhiệm. Bạn thích làm việc theo quy trình, cẩn trọng trong mọi việc và luôn hướng đến chất lượng."
        };

        public static string GetDescription(string discType)
        {
            return Descriptions.TryGetValue(discType, out var description)
                ? description
                : "Không tìm thấy mô tả phù hợp cho kiểu DISC này.";
        }
    }
}