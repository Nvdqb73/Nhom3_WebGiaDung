Use master

Create Database WebGiaDung
go

Use WebGiaDung
go


Create table [KhachHang]
(
	[MaKH] Integer NOT NULL IDENTITY,
	[UserName] Varchar(20) NOT NULL,
	[Password] Varchar(20) NOT NULL,
	[TenKhachHang] Nvarchar(100) NOT NULL,
	[Email] Nvarchar(100) NOT NULL,
	[SDT]  Varchar(11) NOT NULL,
	[DiaChi] Nvarchar(100) NOT NULL,
	[RoleID] Integer NOT NULL,
Primary Key ([MaKH])
) 
go

Create table [SanPham]
(
	[MaSP] Integer NOT NULL IDENTITY,
	[TenSP] Nvarchar(200) NOT NULL,
	[Hinh] Nvarchar(100) NULL,
	[GiaSP] Integer NOT NULL CHECK ([GiaSP]>0),
	[SoLuongTon] Integer NOT NULL CHECK ([SoLuongTon]>=0),
	[MoTa] Nvarchar(1000) NULL,
	[MaLoai] Integer NOT NULL,
	[MaNCC] Integer NOT NULL,
Primary Key ([MaSP])
) 
go

Create table [Loai]
(
	[MaLoai] Integer NOT NULL IDENTITY,
	[TenLoai] Nvarchar(100) NOT NULL,
	[Hinh] Nvarchar (100) NOT NULL,
Primary Key ([MaLoai])
) 
go

Create table [NCC]
(
	[MaNCC] Integer NOT NULL IDENTITY,
	[TenNCC] Nvarchar(50) NOT NULL,
	[Email] Nvarchar(50) NOT NULL,
	[SDT] Varchar(11) NOT NULL,
	[Diachi] Nvarchar(50) NOT NULL,
Primary Key ([MaNCC])
) 
go

Create table [DonHang]
(
	[MaDH] Integer NOT NULL IDENTITY,
	[NgayDatHang] Datetime NOT NULL DEFAULT GETDATE(),
	[NgayGiaoHangDuKien] Datetime NOT NULL DEFAULT GETDATE(),
	[TongTienDonHang] Decimal(10,2) NOT NULL,
	[TrangThai] Varchar(20) NOT NULL CHECK ([TrangThai]='Đã giao' OR [TrangThai]='Chưa giao'),
	[MaKH] Integer NOT NULL,
	[MaTT] Integer NOT NULL,
Primary Key ([MaDH],[MaTT])
) 
go

Create table [ThanhToan]
(
	[MaTT] Integer NOT NULL IDENTITY,
	[TenTT] Nvarchar(50) NOT NULL,
Primary Key ([MaTT])
) 
go

Create table [ChiTietDonHang]
(
	[MaCTDH] Integer NOT NULL IDENTITY,
	[MaDH] Integer NOT NULL,
	[MaTT] Integer NOT NULL,
	[MaSP] Integer NOT NULL,
	[SoLuongMua] Integer NOT NULL,
	[TongTien] Decimal(10,2) NULL,
Primary Key ([MaCTDH],[MaDH],[MaTT],[MaSP])
) 
go

Create table [Role]
(
	[RoleID] Integer NOT NULL IDENTITY,
	[RoleName] Nvarchar(20) NULL,
Primary Key ([RoleID])
) 
go


Alter table [DonHang] add  foreign key([MaKH]) references [KhachHang] ([MaKH])  on update no action on delete no action 
go
Alter table [ChiTietDonHang] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update no action on delete no action 
go
Alter table [SanPham] add  foreign key([MaLoai]) references [Loai] ([MaLoai])  on update no action on delete no action 
go
Alter table [SanPham] add  foreign key([MaNCC]) references [NCC] ([MaNCC])  on update no action on delete no action 
go
Alter table [ChiTietDonHang] add  foreign key([MaDH],[MaTT]) references [DonHang] ([MaDH],[MaTT])  on update no action on delete no action 
go
Alter table [DonHang] add  foreign key([MaTT]) references [ThanhToan] ([MaTT])  on update no action on delete no action 
go
Alter table [KhachHang] add  foreign key([RoleID]) references [Role] ([RoleID])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


--Role
INSERT Role VALUES ('Admin')
INSERT Role VALUES ('NguoiDung')
-- Thanh toan
go
INSERT ThanhToan VALUES (N'Tiền mặt')
INSERT ThanhToan VALUES ('Momo')

-- NCC
go
INSERT NCC VALUES ('SunHouse', 'sunhouse@gmail.com', '016645099', N'123 Hải Thượng Lãng Ông, Quận 5, TP.HCM')
INSERT NCC VALUES ('Toshiba', 'toshiba@gmail.com', '016645099', N'123 Nguyễn Trãi, Quận 5, TP.HCM')
INSERT NCC VALUES ('Sharp', 'sharp@gmail.com', '016645099', N'123 Phạm Văn Đồng, Quận 5, TP.HCM')
-- Loai
go
INSERT Loai VALUES (N'Các loại nồi', '/Content/images/l1.jpg')
INSERT Loai VALUES (N'Quạt, Máy làm mát', '/Content/images/l2.jpg')
INSERT Loai VALUES (N'Quạt, Máy làm mát', '/Content/images/l3.jpg')
INSERT Loai VALUES (N'Máy hút bụi', '/Content/images/l4.jpg')
INSERT Loai VALUES (N'Lò vi sóng', '/Content/images/l5.jpg')
INSERT Loai VALUES (N'Đồ dùng nhà bếp', '/Content/images/l6.jpg')
INSERT Loai VALUES (N'Các loại bếp', '/Content/images/l7.jpg')
INSERT Loai VALUES (N'Máy xay đa năng', '/Content/images/l8.jpg')
INSERT Loai VALUES (N'Máy lọc nước', '/Content/images/l9.jpg')
INSERT Loai VALUES (N'Máy làm kem', '/Content/images/l10.jpg')

-- Sản phẩm
	-- Các loại nồi
INSERT SanPham VALUES (N'Nồi cơm điện Sharp KSH-1010C (KSH-D1010V) - 10 lít', '/Content/images/sp2.jpg', 3250000, 100, 
							N'Loại: Dùng điện. Kiểu nồi: Nắp rời. Dung tích: 10 lít. Công suất: 2.750W.', 1, 1)
INSERT SanPham VALUES (N'Nồi cơm điện Cuckoo CR-3521S (6,3 lít)', '/Content/images/sp1.jpg', 2290000, 100, 
							N'Loại: Dùng điện. Kiểu nồi: Nắp liền. Dung tích: 6,3 lít. Công suất: 1.750W.', 1, 2)

	-- Quạt, Máy làm mát
INSERT SanPham VALUES (N'Quạt tháp có điều khiển Tiross TS9182 ', '/Content/images/sp7.jpg', 3090000, 100, 
							N'Công suất: 35W. Loại: Quạt tháp. Tốc độ gió: 12 tốc độ. Chế độ gió: 3 chế độ. Điều khiển từ xa: Có', 2, 1)
INSERT SanPham VALUES (N'Quạt tháp 2 chiều sưởi ấm và làm mát Ultty', '/Content/images/sp8.jpg', 4650000, 100, 
							N'Công suất: Định danh (2.000W),Làm mát (30W),Tiêu thụ (1.800W). Quạt tháp. Tốc độ gió: Làm ấm, mát', 2, 2)

	-- Máy pha cà phê
INSERT SanPham VALUES (N'Máy pha cà phê Espresso Zamboo ZB90-PRO', '/Content/images/sp12.jpg', 2790000, 100, 
							N'Loại máy: Máy pha cà phê gia đình. Công suất pha cà phê: 20 - 30 tách/ngày', 3, 1)
INSERT SanPham VALUES (N'Máy pha cà phê Melitta Caffeo Solo', '/Content/images/sp13.jpg', 14900000, 100, 
							N'Chức năng pha cà phê: Espresso. Công suất pha cà phê: 40 - 50 tách/ngày.', 3, 1)

	-- Máy hút bụi
INSERT SanPham VALUES (N'Robot hút bụi lau nhà Ultty SKJ RB01X', '/Content/images/sp17.jpg', 5500000, 100, 
							N'Loại máy hút: Robot hút bụi lau nhà. Lực hút: 2.000Pa. Chức năng: Hút bụi và Lau nhà', 4, 2)
INSERT SanPham VALUES (N'Máy hút bụi không dây Mocato Yuka A8', '/Content/images/sp18.jpg', 2390000, 100, 
							N'Loại máy hút: Dùng pin. Lực hút: Chế độ Eco (12.000 Pa), Chế độ Turbo (20.000Pa). Chức năng: Hút bụi. Diện tích sử dụng: 200m2', 4, 2)

	-- Lò vi sóng
INSERT SanPham VALUES (N'Lò vi sóng Toshiba ER-SS23(W1)VN 23 lít', '/Content/images/sp22.jpg', 2290000, 100, 
							N'Loại vi sóng: Lò vi sóng điện tử. Chức năng: Hâm nóng, Nấu, Rã đông. Kiểu lò vi sóng: Không nướng. Dung tích: 23 lít. Công suất: 800W', 5, 1)
INSERT SanPham VALUES (N'Lò vi sóng có nướng 25 lít Electrolux EMG25D59EB', '/Content/images/sp23.jpg', 3090000, 100, 
							N'Loại vi sóng: Lò vi sóng cơ. Chức năng: Hâm nóng, Nấu, Nướng, Rã đông. Kiểu lò vi sóng: Có nướng. Dung tích: 25 lít. Công suất: Nướng (1.000W), Vi sóng (900W)', 5, 2)


	-- Các loại bếp
INSERT SanPham VALUES (N'Bếp từ cảm ứng Nagakawa NAG0704', '/Content/images/sp32.jpg', 899000, 100, 
							N'Loại nồi nấu:Chảo có đế từ, Nồi có đế từ, Mâm từ:Đồng,Chất liệu mặt bếp:Kính chịu lực, chịu nhiệt', 7, 1)
INSERT SanPham VALUES (N'Bếp từ cảm ứng Coex CI-3305 (kèm nồi lẩu)', '/Content/images/sp33.jpg', 1290000, 100, 
							N'Kiểu bếp:Bếp từ đơn, Chất liệu mặt bếp:Kính chịu lực, chịu nhiệt, Bảng điều khiển: Cảm ứng', 7, 3)

-- Máy xay đa năng
INSERT SanPham VALUES (N'Máy xay sinh tố công nghiệp chống ồn Uniblend UB-712', '/Content/images/sp37.jpg', 2950000, 100, 
			                   N'Công suất1.680W Chất liệu vỏ máy: Nhựa cao cấp, Chất liệu cối xay: Nhựa cao cấp', 8, 1)
INSERT SanPham VALUES (N'Máy xay đa năng Promix PM-919B', '/Content/images/sp38.jpg', 3290000, 100, 
							N'Công suất1.500W, Chất liệu vỏ máy:Nhựa cao cấp, Chất liệu cối xay: Nhựa cao cấp', 8, 3)

	-- Máy lọc nước
INSERT SanPham VALUES (N'Máy lọc nước trực tiếp RO Toshiba TWP-W1643SV', '/Content/images/sp42.jpg', 5999000, 100, 
							N'Loại máy lọc nước:RO, Kiểu lắp đặt:Tủ đứng, Công nghệ lọc:Thẩm thấu ngược RO', 9, 2)
INSERT SanPham VALUES (N'Máy lọc nước tinh khiết RO thông minh FujiE RO-08 (RO-03/003A 8 cấp lọc)', '/Content/images/sp43.jpg', 3770000, 100, 
							N'Kiểu lắp đặt:Âm tủ bếp, Tủ đứng, Số lõi: 8 lõi, Loại van: Van điện từ', 9, 3)

	-- Máy làm kem
INSERT SanPham VALUES (N'Máy làm kem tươi Tiross TS-9091', '/Content/images/sp47.jpg', 3050000, 100, 
							N'Loại máy làm kem:Gia đình , Dung tích: 1 lít , Công suất: 90W', 10, 3)
INSERT SanPham VALUES (N'Máy làm kem tươi Hải Âu HAK 322P (Premium)', '/Content/images/sp48.jpg', 6500000, 100, 
							N'Chất làm lạnh: Gas R404A , Số lượng ngăn chứa:2 , Số lượng vòi: 3', 10, 3)
