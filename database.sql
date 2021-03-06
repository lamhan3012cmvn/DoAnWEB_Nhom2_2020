
--CREATE DATABASE [Manager_Book]

USE [Manager_Book]
GO
/****** Object:  Table [dbo].[AUTH]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTH](
	[_email_ID] [varchar](40) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[powers] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_email_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AUTHOR]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTHOR](
	[_id] [varchar](40) NOT NULL,
	[nameAuthor] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILL]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL](
	[order_id] [varchar](40) NOT NULL,
	[information_id] [varchar](40) NOT NULL,
	[book_id] [varchar](40) NOT NULL,
	[total] [float] NULL,
	[order_date] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[information_id] ASC,
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOOK]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOOK](
	[_id] [varchar](40) NOT NULL,
	[nameBook] [nvarchar](50) NOT NULL,
	[priceBook] [float] NOT NULL,
	[contentBook] [nvarchar](max) NULL,
	[countBook] [int] NOT NULL,
	[imgBook_ID] [varchar](40) NOT NULL,
	[categoryBook_ID] [varchar](40) NOT NULL,
	[discountBook_ID] [varchar](40) NULL,
	[publishingHouseBook_ID] [varchar](40) NOT NULL,
	[author_id] [varchar](40) NOT NULL,
	[size] [varchar](40) NULL,
	[numberOfPages] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CART]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CART](
	[information_id] [varchar](40) NOT NULL,
	[book_id] [varchar](40) NOT NULL,
	[count] [int] NULL,
	[order_date] [datetime] NULL,
 CONSTRAINT [PK_CART] PRIMARY KEY CLUSTERED 
(
	[information_id] ASC,
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[_id] [varchar](40) NOT NULL,
	[nameCategory] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DISCOUNT_BOOK]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DISCOUNT_BOOK](
	[_id] [varchar](40) NOT NULL,
	[discount] [float] NOT NULL,
	[startTime] [date] NOT NULL,
	[endTime] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMAGE_BOOK]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMAGE_BOOK](
	[_id] [varchar](40) NOT NULL,
	[link] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMPORT_BOOK]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMPORT_BOOK](
	[book_ID] [varchar](40) NOT NULL,
	[import_date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[book_ID] ASC,
	[import_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INFORMATION]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INFORMATION](
	[_id] [varchar](40) NOT NULL,
	[nameInformation] [nvarchar](50) NOT NULL,
	[maleInformation] [nvarchar](3) NOT NULL,
	[phoneInformation] [varchar](10) NOT NULL,
	[addressInformation] [nvarchar](50) NOT NULL,
	[birthday] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PUBLISHING_HOUSE]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUBLISHING_HOUSE](
	[_id] [varchar](40) NOT NULL,
	[namePublishingHouse] [nvarchar](100) NOT NULL,
	[phonePublishingHouse] [varchar](10) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REVIEWS]    Script Date: 12/2/2020 9:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REVIEWS](
	[book_id] [varchar](40) NOT NULL,
	[information_id] [varchar](40) NOT NULL,
	[review] [nvarchar](max) NOT NULL,
	[star] [int] NOT  NULL,
	[DateOfReview] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[book_id] ASC,
	[information_id] ASC,
	[DateOfReview] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AUTH] ([_email_ID], [password], [powers]) VALUES (N'abc@gmail.com', N'123', N'0')
INSERT [dbo].[AUTH] ([_email_ID], [password], [powers]) VALUES (N'lamhan@gmail.com', N'123', N'1')
INSERT [dbo].[AUTH] ([_email_ID], [password], [powers]) VALUES (N'lamlam@gmail.com', N'123', N'0')
INSERT [dbo].[AUTH] ([_email_ID], [password], [powers]) VALUES (N'nhuquynh@gmail.com', N'123', N'1')
INSERT [dbo].[AUTH] ([_email_ID], [password], [powers]) VALUES (N'nunu@gmail.com', N'123', N'0')
INSERT [dbo].[AUTH] ([_email_ID], [password], [powers]) VALUES (N'quynh@gmail.com', N'123', N'0')
GO
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG01', N'Tô Hoài')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG02', N'Nguyễn Đình Thi')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG03', N'Văn Thành Lê')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG04', N'Nguyễn Nhật Ánh')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG05', N'Tịnh Lâm')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG06', N'Gosho Aoyama')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG07', N'Eiichiro Oda')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG08', N'Fujiko F Fujio')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG09', N'Nguyễn Hiến Lê')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG10', N'Vũ Mai Phương')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG11', N'Nguyễn Thu Hiền')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG12', N'Hoàng Thu Quỳnh')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG13', N'Đỗ Nhung')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG14', N'Châu Văn Văn')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG15', N'Rosie Nguyễn ')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG16', N'Bubu Hương')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG17', N'Nguyễn Nga')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG18', N'Hồng Sakura')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG19', N'Trần Khánh Dư')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG20', N'Đinh Mặc ')
INSERT [dbo].[AUTHOR] ([_id], [nameAuthor]) VALUES (N'TG21', N'Nhiều tác giả')
GO
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS01', N'Có Hai Con Mèo Ngồi Bên Cửa Sổ', 35000, N'Nhân vật chính thứ nhất tên là Gấu.

Nhân vật thứ hai là Tí Hon.

Nhân vật thứ ba, tên là…; còn nữa, nhân vật thứ tư, tên là…

Để biết tại sao Gấu lại chơi thân với Tí Hon, thì mời bạn hãy mở sách ra.

Gấu và Tí Hon thân nhau đến mức có thể chia sẻ từng chuyện vui buồn trong những phút giây mềm yếu, lo lắng và chăm sóc, giúp nhau từ miếng ăn đến “chiến lược” để tồn tại lâu dài.Tình bạn là gì? Bạn gái là gì? Tình yêu là gì?
Bọn mèo chuột kể với chúng ta nhiều câu chuyện nhỏ, gửi thông điệp rằng, tình yêu có sức mạnh tuyệt diệu, có thể làm nên mọi điều phi thường trong cuộc sống muôn loài.

Cuốn truyện có độ dầy vừa phải, 67 hình vẽ của họa sĩ Đỗ Hoàng Tường sinh động đến từng nét nũng nịu hay kiêu căng của nàng mèo người yêu mèo Gấu, câu chuyện thì hấp dẫn duyên dáng điểm những bài thơ tình lãng mạn nao lòng song đọc to lên thì khiến cười hinh hích…

Bạn hãy đọc nhé, để thấy, Nguyễn Nhật Ánh đã viết truyện mèo chuột theo cái cách của riêng mình độc đáo như thế nào.

Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...', 30, N'img01', N'CT01', NULL, N'NXB2', N'TG04', N'13 x 20 x 10 cm', 123)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS02', N'Cái Tết Của Mèo Con', 35000, N'abc', 20, N'img02', N'CT01', NULL, N'NXB6', N'TG02', N'13 x 20 x 10 cm', 123)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS03', N'Trên đồi, mở mắt và mơ', 35000, N'abc', 10, N'img03', N'CT01', NULL, N'NXB1', N'TG03', N'13 x 20 x 10 cm', 123)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS04', N'Dế Mèn Phiêu Lưu Kí', 50000, N'ABC', 15, N'img04', N'CT02', NULL, N'NXB1', N'TG01', N'13 x 20 x 10 cm', 123)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS05', N'Họa Sĩ Nhí Tô Màu', 20000, N'abc', 10, N'img05', N'CT03', NULL, N'NXB1', N'TG05', N'13 x 20 x 10 cm', 123)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS06', N'Conan', 20000, N'abc', 20, N'img06', N'CT04', NULL, N'NXB1', N'TG06', N'13 x 20 x 10 cm', 123)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS07', N'One Piece', 20000, N'abc', 10, N'img07', N'CT04', NULL, N'NXB1', N'TG07', N'13 x 20 x 10 cm', 111)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS08', N'Doraemon', 20000, N'abc', 10, N'img08', N'CT04', NULL, N'NXB1', N'TG08', N'13 x 20 x 10 cm', 222)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS09', N'Gương Danh Nhân ', 35000, N'abc ', 12, N'img09', N'CT05', NULL, N'NXB4', N'TG09', N'13 x 20 x 10 cm', 333)
INSERT [dbo].[BOOK] ([_id], [nameBook], [priceBook], [contentBook], [countBook], [imgBook_ID], [categoryBook_ID], [discountBook_ID], [publishingHouseBook_ID], [author_id], [size], [numberOfPages]) VALUES (N'MS10', N'999 Câu Hỏi Trắc Nghiệm Tiếng Anh', 50000, N'abc', 10, N'img10', N'CT06', NULL, N'NXB5', N'TG09', N'13 x 20 x 10 cm', 111)
GO
INSERT [dbo].[CART] ([information_id], [book_id], [count], [order_date]) VALUES (N'lamlam@gmail.com', N'MS01', 9, CAST(N'2020-12-02T16:56:22.420' AS DateTime))
INSERT [dbo].[CART] ([information_id], [book_id], [count], [order_date]) VALUES (N'quynh@gmail.com', N'MS01', 2, CAST(N'2020-11-09T00:00:00.000' AS DateTime))
INSERT [dbo].[CART] ([information_id], [book_id], [count], [order_date]) VALUES (N'quynh@gmail.com', N'MS02', 1, CAST(N'2020-11-09T00:00:00.000' AS DateTime))
INSERT [dbo].[CART] ([information_id], [book_id], [count], [order_date]) VALUES (N'quynh@gmail.com', N'MS03', 1, CAST(N'2020-11-09T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[CATEGORY] ([_id], [nameCategory]) VALUES (N'CT01', N'Sách Văn Học')
INSERT [dbo].[CATEGORY] ([_id], [nameCategory]) VALUES (N'CT02', N'Hồi ký/Tự Truyện')
INSERT [dbo].[CATEGORY] ([_id], [nameCategory]) VALUES (N'CT03', N'Sách Trẻ Em')
INSERT [dbo].[CATEGORY] ([_id], [nameCategory]) VALUES (N'CT04', N'Truyện Tranh')
INSERT [dbo].[CATEGORY] ([_id], [nameCategory]) VALUES (N'CT05', N'Sách Kinh Tế')
INSERT [dbo].[CATEGORY] ([_id], [nameCategory]) VALUES (N'CT06', N'Sách Anh Văn')
GO
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img01', N'/Content/img/book/book-cover/b-c-HaiConMeo.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img02', N'/Content/img/book/book-cover/b-c-CaiTetMeoCon.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img03', N'/Content/img/book/book-cover/b-c-TrenDoi.png')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img04', N'/Content/img/book/book-cover/b-c-DeMen.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img05', N'/Content/img/book/book-cover/b-c-ToMau.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img06', N'/Content/img/book/book-cover/b-c-CoNan.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img07', N'/Content/img/book/book-cover/b-c-OnePiece.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img08', N'/Content/img/book/book-cover/b-c-Doraemon.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img09', N'/Content/img/book/book-cover/b-c-GuongDanhNhan.jpg')
INSERT [dbo].[IMAGE_BOOK] ([_id], [link]) VALUES (N'img10', N'/Content/img/book/book-cover/b-c-TracNghiem.jpg')
GO
INSERT [dbo].[INFORMATION] ([_id], [nameInformation], [maleInformation], [phoneInformation], [addressInformation], [birthday]) VALUES (N'abc@gmail.com', N'Nụ Nụ Max CuTe', N'Nữ', N'0123456789', N'TPHCM', CAST(N'1999-10-10' AS Date))
INSERT [dbo].[INFORMATION] ([_id], [nameInformation], [maleInformation], [phoneInformation], [addressInformation], [birthday]) VALUES (N'lamlam@gmail.com', N'Lam', N'Nam', N'0123456895', N'HN', CAST(N'2000-01-01' AS Date))
INSERT [dbo].[INFORMATION] ([_id], [nameInformation], [maleInformation], [phoneInformation], [addressInformation], [birthday]) VALUES (N'nunu@gmail.com', N'Nu Nu ', N'#', N'0435437857', N'TPHCM', CAST(N'2000-11-28' AS Date))
INSERT [dbo].[INFORMATION] ([_id], [nameInformation], [maleInformation], [phoneInformation], [addressInformation], [birthday]) VALUES (N'quynh@gmail.com', N'Nguyễn Thị Như Quỳnh', N'#', N'0985194510', N'TPHCM', CAST(N'2020-11-24' AS Date))
GO
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB1', N'Kim Đồng', N'0946983948', N'Quận Hoàn Kiếm, Hà Nội')
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB2', N'Trẻ', N'0385475289', N'Quận Hai Bà Trưng, Hà Nội')
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB3', N'AlphaBook', N'0949573875', N'Quận 1, Thành Phố Hồ Chí Minh')
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB4', N'Hồng Đức', N'0948572899', N'Quận 3, Thành Phố Hồ Chí Minh')
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB5', N'Đại học quốc gia Hà Nội', N'0928334345', N'Quận Long Biên, Hà Nội')
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB6', N'Văn Học', N'0934857828', N'Quận 3, Thành Phố Hồ Chí Minh')
INSERT [dbo].[PUBLISHING_HOUSE] ([_id], [namePublishingHouse], [phonePublishingHouse], [address]) VALUES (N'NXB7', N'Hội Nhà Văn ', N'0934758299', N'Quận Ba Đình, Hà Nội')
GO
INSERT [dbo].[REVIEWS] ([book_id], [information_id], [review], [star], [DateOfReview]) VALUES (N'MS01', N'abc@gmail.com', N'Nụ  ngáo', 3, CAST(N'2020-12-02T16:50:02.527' AS DateTime))
INSERT [dbo].[REVIEWS] ([book_id], [information_id], [review], [star], [DateOfReview]) VALUES (N'MS01', N'lamlam@gmail.com', N'Nụ Nụ Cute Quá đi', 5, CAST(N'2020-12-02T16:44:46.407' AS DateTime))
INSERT [dbo].[REVIEWS] ([book_id], [information_id], [review], [star], [DateOfReview]) VALUES (N'MS01', N'nunu@gmail.com', N'sách hay', 4, CAST(N'2020-11-29T00:00:00.000' AS DateTime))
INSERT [dbo].[REVIEWS] ([book_id], [information_id], [review], [star], [DateOfReview]) VALUES (N'MS01', N'quynh@gmail.com', N'sách hay', 5, CAST(N'2020-11-28T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD  CONSTRAINT [FK_BILL_BOOK] FOREIGN KEY([book_id])
REFERENCES [dbo].[BOOK] ([_id])
GO
ALTER TABLE [dbo].[BILL] CHECK CONSTRAINT [FK_BILL_BOOK]
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD  CONSTRAINT [FK_BILL_INFORMATION] FOREIGN KEY([information_id])
REFERENCES [dbo].[INFORMATION] ([_id])
GO
ALTER TABLE [dbo].[BILL] CHECK CONSTRAINT [FK_BILL_INFORMATION]
GO
ALTER TABLE [dbo].[BOOK]  WITH CHECK ADD  CONSTRAINT [FK_BOOK_AUTHOR] FOREIGN KEY([author_id])
REFERENCES [dbo].[AUTHOR] ([_id])
GO
ALTER TABLE [dbo].[BOOK] CHECK CONSTRAINT [FK_BOOK_AUTHOR]
GO
ALTER TABLE [dbo].[BOOK]  WITH CHECK ADD  CONSTRAINT [FK_BOOK_CATEGORY] FOREIGN KEY([categoryBook_ID])
REFERENCES [dbo].[CATEGORY] ([_id])
GO
ALTER TABLE [dbo].[BOOK] CHECK CONSTRAINT [FK_BOOK_CATEGORY]
GO
ALTER TABLE [dbo].[BOOK]  WITH CHECK ADD  CONSTRAINT [FK_BOOK_DISCOUNT_BOOK] FOREIGN KEY([discountBook_ID])
REFERENCES [dbo].[DISCOUNT_BOOK] ([_id])
GO
ALTER TABLE [dbo].[BOOK] CHECK CONSTRAINT [FK_BOOK_DISCOUNT_BOOK]
GO
ALTER TABLE [dbo].[BOOK]  WITH CHECK ADD  CONSTRAINT [FK_BOOK_IMAGE_BOOK] FOREIGN KEY([imgBook_ID])
REFERENCES [dbo].[IMAGE_BOOK] ([_id])
GO
ALTER TABLE [dbo].[BOOK] CHECK CONSTRAINT [FK_BOOK_IMAGE_BOOK]
GO
ALTER TABLE [dbo].[BOOK]  WITH CHECK ADD  CONSTRAINT [FK_BOOK_PUBLISHING_HOUSE] FOREIGN KEY([publishingHouseBook_ID])
REFERENCES [dbo].[PUBLISHING_HOUSE] ([_id])
GO
ALTER TABLE [dbo].[BOOK] CHECK CONSTRAINT [FK_BOOK_PUBLISHING_HOUSE]
GO
ALTER TABLE [dbo].[CART]  WITH CHECK ADD  CONSTRAINT [FK_CART_BOOK] FOREIGN KEY([book_id])
REFERENCES [dbo].[BOOK] ([_id])
GO
ALTER TABLE [dbo].[CART] CHECK CONSTRAINT [FK_CART_BOOK]
GO
ALTER TABLE [dbo].[CART]  WITH CHECK ADD  CONSTRAINT [FK_CART_INFORMATION] FOREIGN KEY([information_id])
REFERENCES [dbo].[INFORMATION] ([_id])
GO
ALTER TABLE [dbo].[CART] CHECK CONSTRAINT [FK_CART_INFORMATION]
GO
ALTER TABLE [dbo].[IMPORT_BOOK]  WITH CHECK ADD  CONSTRAINT [FK_IMPORT_BOOK_BOOK] FOREIGN KEY([book_ID])
REFERENCES [dbo].[BOOK] ([_id])
GO
ALTER TABLE [dbo].[IMPORT_BOOK] CHECK CONSTRAINT [FK_IMPORT_BOOK_BOOK]
GO
ALTER TABLE [dbo].[INFORMATION]  WITH CHECK ADD  CONSTRAINT [FK_INFORMATION_AUTH] FOREIGN KEY([_id])
REFERENCES [dbo].[AUTH] ([_email_ID])
GO
ALTER TABLE [dbo].[INFORMATION] CHECK CONSTRAINT [FK_INFORMATION_AUTH]
GO
ALTER TABLE [dbo].[REVIEWS]  WITH CHECK ADD  CONSTRAINT [FK_REVIEWS_BOOK] FOREIGN KEY([book_id])
REFERENCES [dbo].[BOOK] ([_id])
GO
ALTER TABLE [dbo].[REVIEWS] CHECK CONSTRAINT [FK_REVIEWS_BOOK]
GO
ALTER TABLE [dbo].[REVIEWS]  WITH CHECK ADD  CONSTRAINT [FK_REVIEWS_INFORMATION] FOREIGN KEY([information_id])
REFERENCES [dbo].[INFORMATION] ([_id])
GO
ALTER TABLE [dbo].[REVIEWS] CHECK CONSTRAINT [FK_REVIEWS_INFORMATION]
GO
USE [master]
GO
ALTER DATABASE [Manager_Book] SET  READ_WRITE 
GO
