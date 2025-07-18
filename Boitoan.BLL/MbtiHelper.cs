using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitoan.BLL
{
    public static class MbtiHelper
    {
        private static readonly Dictionary<string, string> MbtiDescriptions = new()
        {
            ["ISTJ"] = "Người trách nhiệm, logic, tận tâm. Thích sự rõ ràng, tuân thủ quy tắc và thực hiện kế hoạch đã định.",
            ["ISFJ"] = "Ân cần, chu đáo, trung thành. Luôn quan tâm đến nhu cầu của người khác và sẵn sàng giúp đỡ.",
            ["INFJ"] = "Trực giác, sâu sắc, định hướng giá trị. Luôn tìm kiếm ý nghĩa sâu xa và mong muốn giúp người khác phát triển.",
            ["INTJ"] = "Chiến lược gia độc lập, logic và sáng tạo. Có tầm nhìn dài hạn và thường làm việc hiệu quả một mình.",
            ["ISTP"] = "Thực tế, linh hoạt và tò mò. Thích khám phá qua trải nghiệm và giỏi xử lý tình huống khẩn cấp.",
            ["ISFP"] = "Dịu dàng, nghệ sĩ và sống theo cảm xúc. Trân trọng cái đẹp và thường kín đáo.",
            ["INFP"] = "Lý tưởng hóa, sáng tạo, trung thành với giá trị cá nhân. Có cái nhìn sâu sắc về con người.",
            ["INTP"] = "Phân tích, tò mò và tư duy trừu tượng. Giỏi phát hiện vấn đề và lý luận logic.",
            ["ESTP"] = "Hành động, linh hoạt, sống động. Hướng ngoại, thích khám phá thế giới và xử lý tình huống nhanh chóng.",
            ["ESFP"] = "Thân thiện, nhiệt tình, thích giải trí. Thích sống trong hiện tại và làm người khác cảm thấy vui vẻ.",
            ["ENFP"] = "Truyền cảm hứng, sáng tạo và giàu năng lượng. Luôn nhìn thấy tiềm năng và khuyến khích người khác phát triển.",
            ["ENTP"] = "Tư duy nhanh, thích tranh luận, sáng tạo. Giỏi khám phá và phá vỡ giới hạn thông thường.",
            ["ESTJ"] = "Lãnh đạo có tổ chức, đáng tin cậy, thực tế. Giỏi quản lý và tuân thủ quy tắc.",
            ["ESFJ"] = "Hòa đồng, trách nhiệm và tận tụy. Thích làm việc nhóm và chăm sóc cộng đồng.",
            ["ENFJ"] = "Truyền cảm hứng, tận tâm và hướng đến con người. Có khả năng lãnh đạo và kết nối cảm xúc.",
            ["ENTJ"] = "Quyết đoán, chiến lược, định hướng mục tiêu. Giỏi tổ chức và dẫn dắt đội nhóm đến thành công."
        };

        public static string GetDescription(string mbtiType)
        {
            return MbtiDescriptions.TryGetValue(mbtiType.ToUpper(), out var desc)
                ? desc
                : "Không tìm thấy mô tả cho loại MBTI này.";
        }
    }

}
