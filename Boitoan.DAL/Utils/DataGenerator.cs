using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Utils;
public class DataGenerator
{

    public static List<Test> GenerateSampleTests(List<Question> allQuestions)
    {
        var tests = new List<Test>();
        var random = new Random();
        var testMethods = Enum.GetValues(typeof(TestMethod)).Cast<TestMethod>().ToList();
        foreach (var method in testMethods)
        {
            // Filter questions by method
            var methodQuestions = allQuestions.Where(q => q.Type == method).ToList();
            for (int i = 0; i < 3; i++)
            {
                // Randomly select questions for the test
                var selectedQuestions = methodQuestions.OrderBy(q => random.Next()).Take(30).ToList(); // Example: 30 questions per test
                tests.Add(new Test
                {
                    Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(),
                    Method = method,
                    Author = $"Author_{method}_{i + 1}",
                    TestDate = DateTime.UtcNow.AddDays(-random.Next(100)),
                    NumberOfQuestions = selectedQuestions.Count,
                    Questions = selectedQuestions,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
            }
        }
        return tests;
    }

    public static List<Question> GenerateSampleQuestions()
    {
        int temp = 0;
        return new List<Question>(){
            new Question() {
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail ="?",
                Options = new List<Option> (){
                    new Option(){
                        Detail = @"Bạn cảm thấy tràn đầy năng lượng khi ở cạnh nhiều người?" ,
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Khi ở một mình?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                },
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Trong một nhóm, bạn thường là người nói nhiều?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Lắng nghe nhiều hơn ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích các hoạt động náo nhiệt, tiệc tùng?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Những buổi gặp mặt nhỏ, yên tĩnh ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thường nói ra suy nghĩ của mình ngay lập tức ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Nghĩ kỹ rồi mới nói ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích giao lưu, kết bạn mới?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Gắn bó với vài người thân thiết?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thấy thoải mái khi thuyết trình?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Cảm thấy lo lắng khi phải nói trước đám đông ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích các hoạt động nhóm?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Thích làm việc độc lập?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn dễ dàng làm quen với người lạ ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Khó mở lòng khi gặp người mới ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thường hành động rồi mới suy nghĩ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Suy nghĩ kỹ rồi mới hành động?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn cảm thấy được nạp lại năng lượng khi trò chuyện với người khác ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Khi ở trong không gian yên tĩnh ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khi gặp khó khăn, bạn thường chia sẻ ngay?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Giữ trong lòng và tự suy ngẫm?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn cảm thấy hào hứng trong môi trường sôi động ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Nhanh mệt khi ở môi trường đó ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích thể hiện cảm xúc ra ngoài?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Giữ cảm xúc cho riêng mình ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn học tốt hơn khi trao đổi trực tiếp ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Khi tự học một mình ?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn dễ hòa nhập trong các tình huống xã hội ?",
                        Value = (AllAnswer) MBTIAnswer.E
                    },
                    new Option(){
                        Detail = @"Cần thời gian để thích nghi?",
                        Value = (AllAnswer) MBTIAnswer.I
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn tin vào kinh nghiệm thực tế?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Tin vào cảm nhận và linh cảm?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khi học một khái niệm mới, bạn cần ví dụ cụ thể?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Bạn hiểu nhanh thông qua lý thuyết?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn quan tâm đến chi tiết ?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Quan tâm đến bức tranh tổng thể ?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn chú trọng hiện tại và thực tế?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Suy nghĩ về tương lai và khả năng ?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn tin vào ""thấy mới tin"" ?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Tin vào những gì có thể xảy ra?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn nhớ thông tin theo thứ tự, mốc thời gian?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Theo ý tưởng và liên kết ?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khi giải quyết vấn đề, bạn tập trung vào hiện trạng?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Tìm hướng đi mới, sáng tạo?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích làm việc có quy trình rõ ràng?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Thích sáng tạo, linh hoạt ?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn dễ nhớ dữ kiện cụ thể ?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Dễ nhớ ý tưởng, ẩn dụ ?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích hướng dẫn từng bước cụ thể?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Muốn hiểu tổng thể để tự làm?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn đánh giá cao sự ổn định?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Đam mê thay đổi và phát triển?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thấy dễ hiểu hơn khi có ví dụ thực tế?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Khi có mô hình và khái niệm trừu tượng?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn chú ý vào chi tiết nhỏ trong mọi việc ?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Nhìn nhận vấn đề ở tầm vĩ mô?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn cảm thấy an tâm khi tuân theo chuẩn mực đã có ?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"Thích thách thức chuẩn mực ?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thường hỏi “nó là gì ?",
                        Value = (AllAnswer) MBTIAnswer.S
                    },
                    new Option(){
                        Detail = @"nó có thể trở thành gì?",
                        Value = (AllAnswer) MBTIAnswer.N
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khi ra quyết định, bạn ưu tiên lý trí ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Ưu tiên cảm xúc, mối quan hệ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn tin rằng sự thật là quan trọng hơn cảm xúc?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Cảm xúc quan trọng ngang với sự thật ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn phê bình người khác một cách thẳng thắn ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Dịu dàng và tế nhị hơn?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn ưu tiên công việc hiệu quả hơn cảm giác người khác ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Cân bằng giữa cả hai ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn dễ tranh luận để bảo vệ quan điểm ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Tránh tranh cãi vì không muốn làm mất lòng ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn có khuynh hướng phân tích lý lẽ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Đặt mình vào cảm xúc của người khác ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn đánh giá cao sự công bằng ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Đánh giá cao sự quan tâm, đồng cảm ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Trong nhóm, bạn là người ra quyết định?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Người hòa giải?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích sự thẳng thắn?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Thích nhẹ nhàng, tế nhị ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khi làm việc, bạn tập trung vào mục tiêu?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Tập trung vào con người?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn dễ chấp nhận các quyết định dựa trên logic ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Dựa trên cảm nhận và lòng tốt ?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khi gặp mâu thuẫn, bạn tìm lý do khách quan?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Cố gắng hiểu cảm xúc đôi bên?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích phân tích ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Thích cảm nhận và sẻ chia?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn cảm thấy ổn khi người khác không đồng tình ?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Cảm thấy khó chịu nếu ai đó buồn vì bạn?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn làm theo đúng quy định, nguyên tắc?",
                        Value = (AllAnswer) MBTIAnswer.T
                    },
                    new Option(){
                        Detail = @"Linh hoạt theo từng người, từng hoàn cảnh?",
                        Value = (AllAnswer) MBTIAnswer.F
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích lập kế hoạch trước ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Thích làm mọi thứ theo cảm hứng ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn cảm thấy thoải mái khi công việc theo lịch trình ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Khi mọi thứ có thể thay đổi ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn hay hoàn thành mọi việc sớm ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Hay để gần deadline mới làm?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn không thích thay đổi kế hoạch đột ngột?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Dễ thích nghi với thay đổi ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích có danh sách “to -do”?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Làm việc tùy theo ưu tiên mỗi lúc ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn cảm thấy hài lòng khi hoàn thành nhiệm vụ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Khi được khám phá điều mới ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thường lên kế hoạch kỹ cho việc học ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Học theo cảm hứng?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn có xu hướng đánh giá nhanh tình huống?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Muốn xem xét từ nhiều góc độ trước khi kết luận?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thấy mệt khi phải thay đổi liên tục?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Thích cảm giác linh hoạt và tự do?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thích làm việc từng bước cụ thể ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Làm nhiều việc cùng lúc ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thấy vui khi mọi thứ rõ ràng?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Khi mọi thứ mở và còn có thể thay đổi ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn lên kế hoạch trước cho cả kỳ nghỉ ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Đi đâu thấy thú vị thì đi ?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn thường kết thúc công việc trước thời hạn ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Hay nước đến chân mới nhảy?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn chọn cách ổn định lâu dài?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Luôn tìm cơ hội mới?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.MBTI,
                Detail = "?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Bạn muốn kiểm soát mọi việc ?",
                        Value = (AllAnswer) MBTIAnswer.J
                    },
                    new Option(){
                        Detail = @"Không ngại sự bất định, mạo hiểm?",
                        Value = (AllAnswer) MBTIAnswer.P
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = "Cách tiếp cận công việc của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chủ động nắm quyền và hướng tới kết quả nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi truyền động lực cho người khác và duy trì bầu không khí tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tập trung vào làm việc nhóm và hỗ trợ mọi người",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đảm bảo độ chính xác và tuân thủ quy trình",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý hạn chót công việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thúc đẩy để hoàn thành trước thời hạn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi coi đó là động lực để duy trì năng lượng cao",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lên kế hoạch cẩn thận để hoàn thành mà không bị căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi kiểm tra kỹ lưỡng từng chi tiết để đảm bảo mọi thứ chính xác trước khi nộp",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phong cách lãnh đạo của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Thẳng thắn và hướng đến mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Lôi cuốn và dễ gây thiện cảm",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Hỗ trợ và kiên nhẫn",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Phân tích kỹ lưỡng và làm việc có phương pháp",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn phản ứng thế nào khi dự án bị chậm tiến độ?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nắm quyền kiểm soát và thúc đẩy cả nhóm để bắt kịp",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi khích lệ tinh thần và tiếp thêm động lực cho nhóm để lấy lại tiến độ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi phối hợp cùng mọi người để bình tĩnh giải quyết sự chậm trễ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi xem xét lại kế hoạch để xác định và khắc phục vấn đề",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Điều gì thúc đẩy bạn nhất trong môi trường làm việc?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Đạt được những mục tiêu đầy tham vọng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Sự công nhận và các mối quan hệ xã hội",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Sự ổn định và tinh thần làm việc nhóm hài hòa",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Độ chính xác và chất lượng trong công việc",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn tiếp cận việc giải quyết vấn đề như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nhanh chóng tìm ra giải pháp hiệu quả nhất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cùng mọi người động não và suy nghĩ sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tìm kiếm giải pháp mà tất cả đều cảm thấy thoải mái",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ lưỡng vấn đề trước khi hành động",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi giao tiếp, bạn ưu tiên điều gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Thẳng thắn, đi thẳng vào vấn đề",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Nhiệt tình, cuốn hút và dễ gần",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Chu đáo và biết lắng nghe, hỗ trợ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Rõ ràng, chi tiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý những lời phê bình như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đối mặt trực tiếp và hành động nếu cần thiết",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cởi mở trao đổi rồi nhanh chóng bỏ qua",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi suy ngẫm và xem xét ảnh hưởng tới tập thể",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá cẩn thận để cải thiện bản thân",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phong cách ra quyết định của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đưa ra quyết định nhanh chóng và dứt khoát",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tham khảo ý kiến người khác và cân nhắc đóng góp của họ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thích dành thời gian cân nhắc và tránh rủi ro",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi dựa vào dữ liệu và phân tích kỹ lưỡng trước khi quyết định",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi gặp khó khăn, bạn thường phản ứng thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nỗ lực nhiều hơn để vượt qua",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ thái độ tích cực và động viên mọi người",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi giữ bình tĩnh và điều chỉnh cách tiếp cận",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích nguyên nhân và lên kế hoạch phòng tránh trong tương lai",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích làm việc nhóm theo cách nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi dẫn dắt và thúc đẩy cả nhóm tiến về phía trước",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi phối hợp cùng mọi người và giữ cho nhóm luôn tràn đầy năng lượng",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi hỗ trợ người khác và giúp duy trì sự hài hòa",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tập trung vào chi tiết và đảm bảo chất lượng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn đối mặt với căng thẳng trong công việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đối diện trực tiếp với thử thách và tiếp tục tiến lên",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi sử dụng sự hài hước và suy nghĩ tích cực để xoa dịu căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi giữ bình tĩnh và dựa vào thói quen để kiểm soát căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi trở nên tập trung và tổ chức hơn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn tiếp cận sự thay đổi là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đón nhận nó và chủ động dẫn đầu trong việc thích nghi",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi xem đó là cơ hội và khuyến khích người khác cùng tham gia",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thích những thay đổi từ từ, không làm xáo trộn thói quen",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích tác động và lập kế hoạch phù hợp",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi bắt đầu một nhiệm vụ mới, bạn thường làm gì trước?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi lao vào và hành động ngay lập tức",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thu thập ý kiến từ người khác và cùng nhau động não",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi chuẩn bị kỹ lưỡng và tiến hành một cách ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi nghiên cứu và lập kế hoạch trước khi hành động",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thường phản ứng thế nào với xung đột?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đối mặt trực tiếp và giải quyết nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cố gắng xoa dịu tình hình và giữ không khí nhẹ nhàng",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tìm kiếm giải pháp hòa bình mà mọi người đều hài lòng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích tình huống và tìm ra giải pháp hợp lý",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Điều gì thúc đẩy bạn đạt được thành công?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khát khao chiến thắng và đạt kết quả cao nhất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Cơ hội truyền cảm hứng và dẫn dắt người khác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Sự hài lòng khi trở thành người đáng tin cậy",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Theo đuổi sự xuất sắc và độ chính xác",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn tiếp nhận phản hồi từ người khác như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi cân nhắc và thay đổi nếu cần thiết",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi trân trọng phản hồi và dùng nó để cải thiện cách tiếp cận",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tiếp thu và điều chỉnh để duy trì sự hòa hợp",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ lưỡng và hoàn thiện công việc của mình",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phong cách lập kế hoạch của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu tham vọng và vạch ra các bước để đạt được chúng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi lập kế hoạch linh hoạt để có thể ứng biến khi cần",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lên kế hoạch cẩn thận để đảm bảo sự ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi xây dựng kế hoạch chi tiết và tuân thủ chặt chẽ",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn ưu tiên công việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi xử lý những nhiệm vụ quan trọng nhất trước",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tập trung vào những công việc cần sự phối hợp với người khác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi ưu tiên những nhiệm vụ giúp duy trì sự ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi sắp xếp công việc dựa trên tầm quan trọng hợp lý",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Câu nào mô tả đúng nhất về đạo đức nghề nghiệp của bạn?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Chăm chỉ và tập trung vào kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Năng động và hướng về con người",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Đáng tin cậy và nhất quán",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tỉ mỉ và kỹ lưỡng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích được công nhận công việc của mình theo cách nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Được công khai ghi nhận thành tích",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Nhận phản hồi tích cực và sự công nhận từ mọi người",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Sự trân trọng và công nhận một cách nhẹ nhàng, kín đáo",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Được ghi nhận về độ chính xác và chất lượng công việc",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn tiếp cận việc học kỹ năng mới là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi học nhanh thông qua trải nghiệm thực tế",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích học tương tác và theo nhóm",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi học theo cách ổn định và có phương pháp",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi nghiên cứu kỹ lưỡng và luyện tập cho tới khi hoàn hảo",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn với các quy tắc hoặc hướng dẫn nghiêm ngặt là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tuân thủ nếu nó giúp đạt được mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi linh hoạt điều chỉnh cho phù hợp với tình huống",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tuân thủ để giữ trật tự",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tôn trọng và làm theo sát sao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn quản lý thời gian như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi ưu tiên những việc mang lại kết quả lớn nhất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cân bằng công việc với các mối quan hệ xã hội",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi duy trì thói quen để quản lý thời gian hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi lên lịch trình cẩn thận để đảm bảo độ chính xác và hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn xử lý rủi ro là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chấp nhận rủi ro có tính toán để đạt mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cân nhắc rủi ro nếu nó mang lại cơ hội thú vị",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tránh rủi ro và giữ sự ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ rủi ro trước khi quyết định",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích đối mặt với thử thách mới trong công việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chủ động đối diện và giải quyết thử thách",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi hợp tác với người khác để tìm giải pháp sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tiếp cận cẩn trọng, cân nhắc tác động lên mọi người",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ lưỡng thử thách trước khi hành động",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Vai trò bạn thường đảm nhận trong các buổi thảo luận nhóm là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi dẫn dắt cuộc trò chuyện và định hướng nội dung",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi đóng góp nhiệt tình và khuyến khích mọi người tham gia",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lắng nghe kỹ và hỗ trợ khi cần thiết",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi cung cấp ý kiến đã được suy nghĩ kỹ dựa trên thực tế",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn khi dự án đột ngột thay đổi là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thích nghi nhanh và tiếp tục thúc đẩy tiến độ",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tìm cách biến sự thay đổi thành điều tích cực và thú vị",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi muốn hiểu rõ lý do thay đổi và thích nghi từ từ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá tác động của thay đổi lên toàn bộ kế hoạch trước khi tiến hành",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phương pháp bạn giao việc là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi giao việc để đảm bảo công việc hoàn thành hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giao việc để mọi người cùng tham gia và có động lực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi giao việc cẩn trọng để mọi người đều cảm thấy thoải mái",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi giao việc cho người có thể đảm bảo tiêu chuẩn cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn chuẩn bị cho những cuộc họp quan trọng như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi lập kế hoạch các điểm chính và mục tiêu rõ ràng để đạt kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi suy nghĩ cách tạo không khí tích cực và cuốn hút mọi người",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi chuẩn bị kỹ lưỡng để cuộc họp diễn ra suôn sẻ và hợp tác",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi thu thập đầy đủ thông tin và chuẩn bị ghi chú chi tiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi đối mặt với hạn chót gấp, bạn phản ứng ra sao?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi làm việc cường độ cao để hoàn thành đúng hạn, hướng tới kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần tích cực và khích lệ mọi người duy trì đà làm việc",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lập kế hoạch cẩn thận để hoàn thành đúng hạn mà không căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tập trung hoàn thành chính xác công việc ngay cả khi chịu áp lực",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích tham gia vào quá trình ra quyết định theo cách nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thích dẫn dắt và đưa ra quyết định nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích cùng mọi người động não và hợp tác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thích hỗ trợ quá trình bằng những ý kiến ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi thích cung cấp phân tích chi tiết trước khi quyết định",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phong cách làm việc nhóm của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chủ động lãnh đạo để đảm bảo nhóm đạt mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi truyền năng lượng và giữ tinh thần nhóm luôn tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thúc đẩy tinh thần hợp tác và đảm bảo ai cũng được tham gia",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tập trung đảm bảo công việc của nhóm chính xác và đạt chất lượng cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý phản hồi về công việc của mình như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tiếp thu và điều chỉnh để nâng cao kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi trân trọng phản hồi và dùng nó để cải thiện mối quan hệ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi coi trọng phản hồi và thay đổi để giữ sự hòa hợp",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ phản hồi để nâng cao độ chính xác công việc",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn coi trọng điều gì nhất trong môi trường làm việc?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khả năng đạt kết quả và đón nhận thử thách",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Bầu không khí tích cực với cơ hội giao lưu xã hội",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Môi trường ổn định và hỗ trợ lẫn nhau",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Môi trường ưu tiên chất lượng và độ chính xác",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn tiếp cận việc xây dựng mối quan hệ (networking) như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi kết nối với những người có thể giúp tôi đạt mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích gặp gỡ và xây dựng mối quan hệ mới",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi kết nối với những người tôi tin tưởng và cùng chia sẻ giá trị",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi xây dựng các mối quan hệ chuyên nghiệp phù hợp với chuyên môn của tôi",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi tiếp nhận một ý tưởng mới, phản ứng đầu tiên của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đánh giá nhanh chóng và quyết định có nên theo đuổi hay không",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi hào hứng khám phá tiềm năng của ý tưởng cùng người khác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi cân nhắc xem ý tưởng đó có phù hợp với kế hoạch và thói quen hiện tại hay không",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ tính khả thi và tác động của ý tưởng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn tiếp cận việc đa nhiệm như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi xử lý nhiều việc cùng lúc để tối đa hóa hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi làm nhiều việc và giữ tinh thần tích cực cho bản thân và người khác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thích tập trung từng việc một để đảm bảo sự nhất quán",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi sắp xếp công việc cẩn thận để từng việc được hoàn thành đạt tiêu chuẩn cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Vai trò bạn thường đảm nhận khi giải quyết xung đột là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chủ động kiểm soát và giải quyết xung đột nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi đóng vai trò hòa giải để giữ bầu không khí tích cực và hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi là người làm dịu tình hình để mọi người tìm được tiếng nói chung",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích vấn đề và đưa ra giải pháp hợp lý",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn cảm thấy thế nào về việc chấp nhận rủi ro trong công việc?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi sẵn sàng chấp nhận rủi ro nếu nó giúp đạt được thành công lớn hơn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cởi mở với rủi ro nếu nó mang lại cơ hội thú vị",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thích tránh rủi ro để duy trì sự ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ rủi ro và tiến hành một cách thận trọng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phương pháp giao tiếp bạn ưa thích là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Thẳng thắn và trực tiếp",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Thân thiện và cuốn hút",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Bình tĩnh và hỗ trợ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Rõ ràng và chi tiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn quản lý dự án như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thúc đẩy dự án, tập trung vào kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ cho dự án sôi động và khuyến khích tinh thần làm việc nhóm",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi đảm bảo dự án diễn ra suôn sẻ và ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi quản lý dự án tỉ mỉ, tập trung vào chất lượng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý những công việc lặp đi lặp lại như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi hoàn thành nhanh chóng để chuyển sang công việc thách thức hơn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tìm cách làm cho chúng thú vị hơn hoặc giao bớt cho người khác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi cảm thấy thoải mái với sự lặp lại và thực hiện đều đặn",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi chú trọng thực hiện chính xác mỗi lần",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi người khác không đồng tình với ý tưởng của bạn, bạn làm gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tranh luận mạnh mẽ và kiên quyết bảo vệ ý tưởng của mình",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi lắng nghe và cố gắng kết hợp ý tưởng của họ với của mình",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tìm kiếm sự thỏa hiệp để làm hài lòng mọi người",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá phản hồi và điều chỉnh ý tưởng dựa trên lý lẽ",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích đặt mục tiêu như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu thách thức và thúc đẩy bản thân đạt được nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu đầy tham vọng và cũng thú vị để theo đuổi",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu thực tế, ổn định mà tôi biết mình có thể đạt được",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu chính xác, có thể đo lường và theo dõi cẩn thận",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý những tình huống mình không kiểm soát được như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi cố gắng giành lại quyền kiểm soát hoặc tác động đến tình huống",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích nghi và cố gắng giữ tinh thần tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi giữ bình tĩnh và thuận theo tình hình để tránh căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tập trung vào những gì mình có thể kiểm soát và quản lý chi tiết cẩn thận",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách tiếp cận của bạn khi bắt đầu một nhiệm vụ mới là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi bắt tay vào làm ngay, tập trung hoàn thành nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi lấy ý kiến của người khác và biến nhiệm vụ trở nên thú vị",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi chuẩn bị kỹ càng trước khi bắt đầu",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi lập kế hoạch từng bước trước khi hành động",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn với những phản hồi mang tính thách thức công việc của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi bảo vệ công việc của mình nhưng sẽ thay đổi nếu cần thiết",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cân nhắc phản hồi và cố gắng cải thiện trong tinh thần tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi chấp nhận phản hồi và điều chỉnh để tránh mâu thuẫn",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ phản hồi và hoàn thiện công việc theo đó",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách tiếp cận của bạn với đổi mới trong công việc là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi dẫn đầu và thúc đẩy việc áp dụng ý tưởng mới nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi hào hứng và khuyến khích mọi người sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi ủng hộ đổi mới nhưng thích áp dụng dần dần",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá rủi ro và lợi ích trước khi áp dụng đổi mới",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn duy trì năng lượng làm việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tập trung vào việc đạt mục tiêu để giữ năng lượng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giao tiếp với mọi người và giữ môi trường làm việc sôi động",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi làm việc với nhịp độ hợp lý và nghỉ ngơi đều đặn để giữ ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi sắp xếp công việc và quản lý thời gian hiệu quả để tránh kiệt sức",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý những cuộc trò chuyện khó khăn như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đối diện trực tiếp và thể hiện sự quyết đoán",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tiếp cận với sự lạc quan và đồng cảm",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi cố gắng giữ cuộc trò chuyện bình tĩnh và tìm tiếng nói chung",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi chuẩn bị kỹ lưỡng và sử dụng dữ liệu thực tế để bảo vệ quan điểm",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi bắt đầu vai trò mới, ưu tiên của bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Thiết lập quyền uy và đạt kết quả nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Xây dựng mối quan hệ và tạo môi trường tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Hiểu rõ đội nhóm và hòa nhập trôi chảy",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Nắm vững quy định, quy trình và kỳ vọng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn khi ai đó không đồng tình với bạn là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi kiên quyết bảo vệ quan điểm của mình",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cố gắng hiểu quan điểm của họ và tìm điểm chung",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lắng nghe kỹ và tìm cách hài hòa hai bên",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi xem xét lập luận của họ và đánh giá một cách logic",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn ưu tiên những việc gì trong ngày làm việc?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Hoàn thành những việc có tác động lớn nhất đến mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Làm những việc có liên quan đến người khác và giữ ngày làm việc năng động",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Đảm bảo công việc được thực hiện ổn định và đáng tin cậy",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tập trung vào những việc cần sự chính xác và chú ý đến chi tiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn phản ứng thế nào với những hạn chót gấp rút?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thúc ép bản thân và mọi người để hoàn thành hoặc vượt hạn chót",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần tích cực và động viên cả nhóm hoàn thành đúng hạn",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lên kế hoạch kỹ để hoàn thành đúng hạn mà không căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tập trung vào độ chính xác, đảm bảo mọi thứ được hoàn thành đúng ngay cả khi bị áp lực thời gian",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi gặp vấn đề phức tạp, bạn xử lý như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nhanh chóng chia nhỏ vấn đề và tập trung giải quyết phần quan trọng nhất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thu thập ý kiến từ người khác và cùng nhau tìm giải pháp sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi dành thời gian hiểu rõ vấn đề trước khi hành động",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ lưỡng mọi khía cạnh và xây dựng kế hoạch chi tiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý thế nào khi làm việc trong môi trường áp lực cao?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi phát huy khả năng dưới áp lực và dùng áp lực để thúc đẩy hiệu suất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ không khí nhẹ nhàng và động viên mọi người duy trì tinh thần tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi dựa vào thói quen và sự ổn định để kiểm soát căng thẳng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi giữ tổ chức công việc và tập trung duy trì tiêu chuẩn cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích nhận hướng dẫn công việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Ngắn gọn và đi thẳng vào vấn đề để tôi bắt tay vào làm ngay",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Nhiệt tình, cho phép linh hoạt và sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Rõ ràng, kèm theo cơ hội đặt câu hỏi để hiểu rõ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Chi tiết, đầy đủ thông tin cần thiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn đảm bảo công việc của mình phù hợp với mục tiêu tổ chức như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tập trung vào kết quả có tác động trực tiếp đến mục tiêu của tổ chức",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi điều chỉnh công việc theo mục tiêu của nhóm và giữ mọi người có động lực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi đảm bảo công việc của mình hỗ trợ sự ổn định và hoạt động chung của nhóm",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tuân thủ nghiêm ngặt các hướng dẫn và đảm bảo độ chính xác trong đóng góp của mình",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi giải quyết vấn đề cùng người khác, bạn tiếp cận như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi dẫn dắt và định hướng cả nhóm tìm ra giải pháp",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tạo môi trường thảo luận cởi mở và khuyến khích tư duy sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lắng nghe ý kiến của mọi người và tìm kiếm sự đồng thuận",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi cung cấp phân tích dựa trên dữ liệu và đề xuất cách tiếp cận có phương pháp",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn khi có người làm gián đoạn công việc là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi xử lý nhanh sự gián đoạn và quay lại công việc",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi hoan nghênh sự gián đoạn nếu nó mang lại ý tưởng hoặc hợp tác mới",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tạm dừng để lắng nghe rồi quay lại công việc một cách bình tĩnh",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi không thích bị gián đoạn nhưng sẽ sắp xếp lại lịch trình để xử lý",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý sự không chắc chắn trong dự án như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi kiểm soát tình hình và đưa ra quyết định để giảm bớt sự không chắc chắn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần lạc quan và khuyến khích sự linh hoạt trong nhóm",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tìm kiếm sự rõ ràng và thích chờ thêm thông tin trước khi hành động",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi thu thập càng nhiều dữ liệu càng tốt để giảm thiểu sự không chắc chắn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi ra quyết định, bạn cân nhắc điều gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khả năng đạt được kết quả tốt nhất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tác động đến con người và các mối quan hệ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Ảnh hưởng đến sự ổn định và nhất quán lâu dài",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Dữ liệu, chi tiết và hệ quả logic",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý thế nào khi phải thay đổi kế hoạch?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi điều chỉnh nhanh chóng và tập trung đạt kết quả với kế hoạch mới",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích nghi và tìm cách giữ tình huống tích cực, thú vị",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thay đổi dần dần, đảm bảo mọi người đều cảm thấy thoải mái với hướng đi mới",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ kế hoạch mới và thực hiện thay đổi một cách tỉ mỉ",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi công việc của bạn bị chỉ trích, bạn phản ứng ra sao?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi bảo vệ công việc nhưng sẽ thay đổi nếu cần để đạt mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi đón nhận nhẹ nhàng và tìm cách cải thiện trong tinh thần tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi coi trọng phản hồi và điều chỉnh để giữ sự hài hòa",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ lưỡng lời chỉ trích và cải tiến để đảm bảo độ chính xác",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn quản lý cân bằng giữa công việc và cuộc sống thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi ưu tiên thời gian để tối đa hóa năng suất và giảm thời gian chết",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tích hợp các hoạt động xã hội vào công việc để giữ cân bằng",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi duy trì thói quen ổn định giữa công việc và cuộc sống cá nhân",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tổ chức lịch trình chặt chẽ để cả công việc và cuộc sống đều có cấu trúc rõ ràng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn học hỏi từ sai lầm là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nhanh chóng vượt qua và dùng trải nghiệm để tiến về phía trước",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi suy ngẫm và chia sẻ với người khác để cùng học hỏi",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi rút kinh nghiệm và điều chỉnh để tránh lặp lại sai lầm",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích nguyên nhân và thay đổi quy trình để ngăn ngừa lỗi tái diễn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách tiếp cận của bạn với việc đặt mục tiêu là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu tham vọng và nỗ lực hết sức để đạt được",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu thách thức nhưng cũng cho phép sự sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu thực tế, khả thi để đảm bảo tiến độ ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đặt mục tiêu chính xác, chi tiết và lập kế hoạch rõ ràng để đạt được",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn với sự quản lý vi mô (bị kiểm soát sát sao) là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi cảm thấy khó chịu và thích làm việc độc lập hơn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tập trung duy trì mối quan hệ tích cực với người quản lý",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi chấp nhận miễn là nó giúp duy trì sự ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá cao sự hướng dẫn nếu nó giúp công việc chính xác và đạt kết quả tốt hơn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn quản lý khối lượng công việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi ưu tiên những việc có tác động lớn nhất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cân bằng công việc với các cơ hội giao tiếp với mọi người",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi làm việc đều đặn, đảm bảo hoàn thành mà không vội vàng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tổ chức công việc một cách tỉ mỉ để duy trì tiêu chuẩn cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách tiếp cận của bạn với dịch vụ khách hàng là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tập trung giải quyết vấn đề nhanh chóng và hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi đảm bảo khách hàng cảm thấy được lắng nghe và trân trọng",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi cố gắng cung cấp dịch vụ ổn định và đáng tin cậy",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đảm bảo mọi chi tiết chính xác và khách hàng nhận được thông tin đầy đủ",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn đối mặt với thất bại như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi coi thất bại là trở ngại tạm thời và nhanh chóng tập trung lại vào thành công",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần lạc quan và tìm bài học từ thất bại",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi suy ngẫm và thực hiện các bước để đảm bảo không lặp lại thất bại",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích kỹ nguyên nhân và lập kế hoạch để ngăn ngừa thất bại sau này",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích xử lý mâu thuẫn tại nơi làm việc như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đối diện trực tiếp và tìm cách giải quyết nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi làm trung gian để tìm giải pháp làm hài lòng tất cả",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi cố gắng tránh mâu thuẫn và duy trì môi trường hòa bình",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tiếp cận logic và hướng đến giải pháp công bằng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Điều gì thúc đẩy bạn thành công?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Khát khao đạt thành tích và tạo ra tác động lớn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Sự hào hứng với cơ hội mới và được công nhận",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Sự hài lòng khi làm tốt và giúp đỡ người khác",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Niềm đam mê theo đuổi sự xuất sắc và độ chính xác trong mọi việc",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích tổ chức không gian làm việc của mình như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi giữ không gian gọn gàng, đầy đủ mọi thứ cần thiết để hành động nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tạo không gian sống động, truyền cảm hứng sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi giữ không gian ngăn nắp, mọi thứ đúng vị trí",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi sắp xếp tỉ mỉ với hệ thống chi tiết cho mọi thứ",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn xử lý dự án mới là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi bắt tay ngay vào làm, tập trung đạt kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tập hợp đội nhóm, đảm bảo mọi người hào hứng và tham gia",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi dành thời gian lập kế hoạch và đảm bảo dự án được tổ chức chặt chẽ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích chi tiết yêu cầu dự án trước khi bắt đầu",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn cảm thấy thế nào về lập kế hoạch dài hạn?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thích tập trung vào kết quả trước mắt và linh hoạt điều chỉnh khi cần",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích lập kế hoạch nếu nó bao gồm hợp tác và sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi coi trọng lập kế hoạch dài hạn vì sự ổn định mà nó mang lại",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi thích những kế hoạch dài hạn chi tiết, tính đến mọi yếu tố",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn truyền đạt hướng dẫn cho người khác là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đưa ra chỉ dẫn rõ ràng, trực tiếp để đảm bảo công việc được hoàn thành",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giải thích thân thiện, khiến hướng dẫn trở nên hấp dẫn",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi kiên nhẫn hướng dẫn, đảm bảo mọi người đều hiểu",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi cung cấp hướng dẫn tỉ mỉ, chi tiết để tránh sai sót",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Điều gì thúc đẩy bạn trong môi trường làm việc nhóm?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Đạt được mục tiêu chung và được công nhận là người dẫn đầu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Xây dựng mối quan hệ và tận hưởng không khí nhóm năng động",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Góp phần xây dựng nhóm ổn định, hòa thuận",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Đảm bảo công việc nhóm đạt chất lượng cao và tuân thủ tiêu chuẩn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi được giao nhiệm vụ bạn không đồng tình, bạn phản ứng thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi sẽ hoàn thành nhưng có thể phản biện nếu nó ảnh hưởng đến kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi sẽ tìm cách làm cho nhiệm vụ thú vị hoặc mang tính hợp tác hơn",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi sẽ thực hiện hết khả năng, tránh xung đột",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi sẽ hoàn thành chính xác nhưng có thể phản hồi lý do tôi không đồng tình",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn đối mặt với căng thẳng là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chuyển căng thẳng thành hành động, tiếp tục tiến lên",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi chia sẻ với người khác và giữ tinh thần tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi kiểm soát căng thẳng bằng cách duy trì thói quen và giữ bình tĩnh",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi giảm căng thẳng bằng cách tổ chức lại công việc và đảm bảo mọi thứ đâu vào đấy",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích giao tiếp với đồng nghiệp theo cách nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Trực tiếp, ngắn gọn, tập trung vào nội dung chính",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Thoải mái, cởi mở, giữ cho cuộc trò chuyện vui vẻ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Điềm tĩnh, suy nghĩ kỹ, đảm bảo mọi người đều được lắng nghe",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Rõ ràng, chính thức, cung cấp đầy đủ thông tin cần thiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn khi có yêu cầu bất ngờ về thời gian là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nhanh chóng ưu tiên và giải quyết những việc quan trọng nhất trước",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi linh hoạt và cố gắng xử lý yêu cầu với sự hứng khởi",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi bình tĩnh quản lý, vẫn bám sát quy trình thường ngày",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ lưỡng yêu cầu để đảm bảo không ảnh hưởng đến chất lượng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn tiếp cận việc học kỹ năng mới là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi tập trung làm chủ kỹ năng nhanh chóng và hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tận hưởng quá trình học và thường mời người khác cùng tham gia",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi học đều đặn, dành thời gian để hiểu rõ kỹ năng",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi nghiên cứu sâu, đảm bảo nắm vững mọi chi tiết",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý công việc lặp đi lặp lại như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi làm nhanh để chuyển sang việc thử thách hơn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi cố gắng làm cho nó vui hơn hoặc tìm cách làm cùng người khác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi kiên nhẫn thực hiện, duy trì sự nhất quán",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tập trung làm chính xác từng lần, đảm bảo tiêu chuẩn cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn cân nhắc điều gì trước khi đưa ra quyết định lớn?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Ảnh hưởng tiềm năng và khả năng triển khai nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tác động đến con người và tinh thần chung",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tác động lâu dài đến sự ổn định của nhóm",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Chi tiết, dữ liệu và rủi ro liên quan",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý việc trì hoãn như thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thúc ép bản thân bắt đầu và hoàn thành nhanh chóng",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tự động viên bằng cách tập trung vào lợi ích khi hoàn thành",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lên lịch rõ ràng và bám sát kế hoạch",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi chia nhỏ công việc để dễ quản lý hơn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Cách bạn tiếp cận khi gia nhập nhóm mới là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nhanh chóng khẳng định vai trò và tập trung thúc đẩy nhóm đạt mục tiêu",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tập trung xây dựng mối quan hệ và tạo bầu không khí tích cực",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi dành thời gian quan sát và hiểu rõ động lực của nhóm",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tìm hiểu quy trình và tiêu chuẩn của nhóm trước khi tham gia đầy đủ",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn khi người khác làm việc thiếu trách nhiệm là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đối mặt trực tiếp và thúc ép họ cải thiện hiệu suất",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi khích lệ và cố gắng tạo động lực tích cực cho họ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi hỗ trợ và tìm cách giúp họ tiến bộ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi nhấn mạnh tầm quan trọng của việc đáp ứng tiêu chuẩn",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn làm gì khi cảm thấy quá tải vì công việc?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi ưu tiên những việc quan trọng nhất và giải quyết dứt điểm",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tìm đến người khác để được hỗ trợ và giữ tinh thần lạc quan",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi lùi lại một bước, sắp xếp lại công việc rồi giải quyết từng việc một",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi lập kế hoạch chi tiết để quản lý khối lượng công việc hiệu quả",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi được giao thêm trách nhiệm, bạn phản ứng thế nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đón nhận thử thách và tập trung đạt kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi xem đó là cơ hội kết nối và phát triển bản thân",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá xem có đảm đương được mà không ảnh hưởng công việc hiện tại không",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi cân nhắc kỹ tác động và đảm bảo vẫn duy trì chất lượng",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn với chính sách hoặc quy trình mới là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thích nghi nhanh nếu nó giúp đạt mục tiêu, nếu không tôi có thể chất vấn",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi tìm điểm tích cực và cố gắng thuyết phục người khác cùng tham gia",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi điều chỉnh từ từ, đảm bảo không làm xáo trộn thói quen",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi nghiên cứu kỹ chính sách để thực hiện chính xác",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích cách nào để đưa ra phản hồi cho người khác?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Trực tiếp, thẳng thắn, tập trung vào cải thiện",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tích cực, vừa khích lệ vừa góp ý",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Nhẹ nhàng, chú trọng duy trì sự hòa hợp",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tỉ mỉ, cung cấp nhận xét chi tiết và đề xuất cụ thể",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Vai trò của bạn trong việc tạo động lực cho người khác là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi thúc ép họ đạt được thành tích và đặt kỳ vọng cao",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi truyền cảm hứng và động viên họ bằng sự nhiệt huyết",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi âm thầm hỗ trợ và động viên đều đặn",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi làm gương bằng chất lượng công việc cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn khi mọi việc không như kế hoạch?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi nhanh chóng điều chỉnh và kiểm soát tình hình",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần tích cực và tìm giải pháp sáng tạo",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi giữ bình tĩnh và cố gắng quay lại đúng hướng một cách từ từ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích nguyên nhân và điều chỉnh kế hoạch cẩn thận",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý thế nào khi phải làm việc với người có phong cách rất khác bạn?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi khẳng định cách làm của mình nhưng sẵn sàng thỏa hiệp nếu cần thiết để đạt kết quả",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi thích nghi và tìm điểm chung để hợp tác vui vẻ",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tập trung tìm cách làm việc hòa hợp với nhau",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi tôn trọng phong cách của họ nhưng vẫn duy trì tiêu chuẩn chất lượng của mình",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn xử lý thế nào khi nhận được phản hồi từ nhiều nguồn khác nhau?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi chọn lọc những gì hữu ích và hành động ngay, bỏ qua phần còn lại",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi lắng nghe tất cả và tìm cách cải thiện cũng như hợp tác",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi cân nhắc kỹ từng phản hồi và áp dụng một cách ổn định",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi phân tích toàn bộ phản hồi và áp dụng khi nó giúp nâng cao độ chính xác",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Phản ứng của bạn với những thử thách bất ngờ là gì?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi kiểm soát tình hình và nhanh chóng tìm cách vượt qua",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần lạc quan và cùng người khác giải quyết thử thách",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi tiếp cận thử thách một cách bình tĩnh và xử lý từ từ",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ mọi khía cạnh và lập kế hoạch đối phó cẩn thận",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Bạn thích ăn mừng thành tựu theo cách nào?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Âm thầm, tập trung vào thử thách tiếp theo",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Công khai, chia sẻ thành công và tận hưởng khoảnh khắc cùng mọi người",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Lặng lẽ, dành thời gian suy ngẫm về thành tựu đạt được",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tỉ mỉ, ghi nhận từng chi tiết và công sức đã bỏ ra",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            },

            new Question(){
                Id = temp++,
                Type = TestMethod.DISC,
                Detail = @"Khi môi trường làm việc cần thay đổi, bạn phản ứng ra sao?",
                Options = new List<Option>(){
                    new Option(){
                        Detail = @"Tôi đón nhận nếu nó giúp đạt kết quả tốt hơn và dẫn dắt quá trình thay đổi",
                        Value = (AllAnswer) DISCAnswer.Dominance
                    },
                    new Option(){
                        Detail = @"Tôi giữ tinh thần tích cực và kết nối mọi người để quá trình chuyển đổi dễ dàng hơn",
                        Value = (AllAnswer) DISCAnswer.Influence
                    },
                    new Option(){
                        Detail = @"Tôi thay đổi từ từ, đảm bảo sự ổn định không bị xáo trộn",
                        Value = (AllAnswer) DISCAnswer.Steadiness
                    },
                    new Option(){
                        Detail = @"Tôi đánh giá kỹ lưỡng thay đổi và điều chỉnh quy trình để duy trì tiêu chuẩn cao",
                        Value = (AllAnswer) DISCAnswer.Conscientiousness
                    }
                }
            }
        };
    }

}
