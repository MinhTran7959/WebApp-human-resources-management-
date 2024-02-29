USE [QLNS]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOPDONG]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOPDONG](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[ViTri] [nvarchar](50) NULL,
	[LoaiHD] [nvarchar](50) NULL,
	[ThoiHan] [nvarchar](50) NULL,
	[TenHD] [nvarchar](50) NULL,
 CONSTRAINT [PK_HOPDONG] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHENTHUONG]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHENTHUONG](
	[MaKT] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGian] [smalldatetime] NULL,
	[QuyetDinh] [nvarchar](50) NULL,
	[MaNV] [int] NULL,
	[Sotienthuong] [nvarchar](50) NULL,
 CONSTRAINT [PK_KHENTHUONG] PRIMARY KEY CLUSTERED 
(
	[MaKT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KYHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KYHD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayKy] [smalldatetime] NULL,
 CONSTRAINT [PK_KYHD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KYLUAT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KYLUAT](
	[MaKL] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGian] [smalldatetime] NULL,
	[QuyetDinh] [nvarchar](50) NULL,
	[MaNV] [int] NULL,
	[Sotienphat] [nvarchar](50) NULL,
 CONSTRAINT [PK_KYLUAT] PRIMARY KEY CLUSTERED 
(
	[MaKL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUONG]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUONG](
	[MaLuong] [int] IDENTITY(1,1) NOT NULL,
	[MucLuongCB] [nvarchar](50) NULL,
 CONSTRAINT [PK_LUONG] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](11) NULL,
	[CCCD] [nvarchar](12) NULL,
	[Noisinh] [nvarchar](50) NULL,
	[Ngaysinh] [smalldatetime] NULL,
	[Gioitinh] [nvarchar](20) NULL,
	[Diachi] [nvarchar](100) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MaPB] [int] IDENTITY(1,1) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUATRINHCHUCVU]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUATRINHCHUCVU](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaCV] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[TGBD] [smalldatetime] NULL,
	[TGKT] [smalldatetime] NULL,
 CONSTRAINT [PK_QUATRINHCHUCVU] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUATRINHCONGTAC]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUATRINHCONGTAC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[MaPB] [int] NOT NULL,
	[TGBD] [smalldatetime] NULL,
	[TGKT] [smalldatetime] NULL,
 CONSTRAINT [PK_QUATRINHCONGTAC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUATRINHLUONG]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUATRINHLUONG](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[MaLuong] [int] NOT NULL,
	[MaPB] [int] NOT NULL,
	[MaCV] [int] NOT NULL,
	[TGBD] [smalldatetime] NULL,
	[TGKT] [smalldatetime] NULL,
 CONSTRAINT [PK_QUATRINHLUONG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[LaQuanTri] [nvarchar](50) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KHENTHUONG]  WITH CHECK ADD  CONSTRAINT [FK_NV_KT] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KHENTHUONG] CHECK CONSTRAINT [FK_NV_KT]
GO
ALTER TABLE [dbo].[KYHD]  WITH CHECK ADD  CONSTRAINT [FK_HD_KYHD] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HOPDONG] ([MaHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KYHD] CHECK CONSTRAINT [FK_HD_KYHD]
GO
ALTER TABLE [dbo].[KYHD]  WITH CHECK ADD  CONSTRAINT [FK_NV_KYHD] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KYHD] CHECK CONSTRAINT [FK_NV_KYHD]
GO
ALTER TABLE [dbo].[KYLUAT]  WITH CHECK ADD  CONSTRAINT [FK_NV_KL] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KYLUAT] CHECK CONSTRAINT [FK_NV_KL]
GO
ALTER TABLE [dbo].[QUATRINHCHUCVU]  WITH CHECK ADD  CONSTRAINT [FK_CV_QTCV] FOREIGN KEY([MaCV])
REFERENCES [dbo].[CHUCVU] ([MaCV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHCHUCVU] CHECK CONSTRAINT [FK_CV_QTCV]
GO
ALTER TABLE [dbo].[QUATRINHCHUCVU]  WITH CHECK ADD  CONSTRAINT [FK_NV_QTCV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHCHUCVU] CHECK CONSTRAINT [FK_NV_QTCV]
GO
ALTER TABLE [dbo].[QUATRINHCONGTAC]  WITH CHECK ADD  CONSTRAINT [FK_NV_QTCT] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHCONGTAC] CHECK CONSTRAINT [FK_NV_QTCT]
GO
ALTER TABLE [dbo].[QUATRINHCONGTAC]  WITH CHECK ADD  CONSTRAINT [FK_PB_QTCT] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PHONGBAN] ([MaPB])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHCONGTAC] CHECK CONSTRAINT [FK_PB_QTCT]
GO
ALTER TABLE [dbo].[QUATRINHLUONG]  WITH CHECK ADD  CONSTRAINT [FK_CV_QTL] FOREIGN KEY([MaCV])
REFERENCES [dbo].[CHUCVU] ([MaCV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHLUONG] CHECK CONSTRAINT [FK_CV_QTL]
GO
ALTER TABLE [dbo].[QUATRINHLUONG]  WITH CHECK ADD  CONSTRAINT [FK_L_QTL] FOREIGN KEY([MaLuong])
REFERENCES [dbo].[LUONG] ([MaLuong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHLUONG] CHECK CONSTRAINT [FK_L_QTL]
GO
ALTER TABLE [dbo].[QUATRINHLUONG]  WITH CHECK ADD  CONSTRAINT [FK_NV_QTL] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHLUONG] CHECK CONSTRAINT [FK_NV_QTL]
GO
ALTER TABLE [dbo].[QUATRINHLUONG]  WITH CHECK ADD  CONSTRAINT [FK_PB_QTL] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PHONGBAN] ([MaPB])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHLUONG] CHECK CONSTRAINT [FK_PB_QTL]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_NV_TK] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_NV_TK]
GO
/****** Object:  StoredProcedure [dbo].[AddChucVu]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddChucVu]
@TenCV nvarchar(50)
as
	begin
		insert into CHUCVU(TenCV) values (@TenCV)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddHopDong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddHopDong]
@ViTri nvarchar(50),
@LoaiHD nvarchar(50),
@ThoiHan nvarchar(50),
@TenHD nvarchar(50)
as
	begin
		insert into HOPDONG(ViTri, LoaiHD, ThoiHan, TenHD) values (@ViTri, @LoaiHD, @ThoiHan, @TenHD)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddKhenThuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddKhenThuong]
@ThoiGian smalldatetime,
@QuyetDinh nvarchar(50),
@Sotienthuong nvarchar(50),
@MaNV int
as
	begin
		insert into KHENTHUONG(ThoiGian, QuyetDinh, Sotienthuong, MaNV) values (@ThoiGian, @QuyetDinh, @Sotienthuong, @MaNV)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddKyHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddKyHD]
@MaHD int,
@MANV int,
@NgayKy smalldatetime
as
	begin
		insert into KYHD(MaHD,MaNV,NgayKy) values (@MaHD,@MANV,@NgayKy)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddKyLuat]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddKyLuat]
@ThoiGian smalldatetime,
@QuyetDinh nvarchar(50),
@Sotienphat nvarchar(50),
@MaNV int
as
	begin
		insert into KYLUAT(ThoiGian, QuyetDinh, Sotienphat, MaNV) values (@ThoiGian, @QuyetDinh, @Sotienphat, @MaNV)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddLuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddLuong]

@MucLuongCB nvarchar(50)
as
	begin
		insert into LUONG(MucLuongCB) values (@MucLuongCB)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddNhanVien]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddNhanVien]
@Hoten nvarchar(50),
@Email nvarchar(50),
@SDT nvarchar(11),
@CCCD nvarchar(12),
@Noisinh nvarchar(50),
@Ngaysinh smalldatetime,
@Gioitinh nvarchar(20),
@Diachi nvarchar(100)
as
	begin
		insert into NHANVIEN(Hoten, Email, SDT, CCCD, Noisinh, Ngaysinh, Gioitinh, Diachi) values (@Hoten, @Email, @SDT, @CCCD, @Noisinh, @Ngaysinh, @Gioitinh, @Diachi)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddPhongBan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddPhongBan]
@TenPB nvarchar(50)
as
	begin
		insert into PHONGBAN(TenPB) values (@TenPB)

	end
GO
/****** Object:  StoredProcedure [dbo].[AddQTCT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddQTCT]
@MaNV int,
@MaPB int, 
@TGBD smalldatetime,
@TGKT smalldatetime
as
	begin
		insert into QUATRINHCONGTAC(MaNV, MaPB, TGBD, TGKT) values (@MaNV, @MaPB, @TGBD, @TGKT)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddQTCV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddQTCV]
@MaCV int, 
@MaNV int, 
@TGBD smalldatetime,
@TGKT smalldatetime
as
	begin
		insert into QUATRINHCHUCVU(MaCV, MaNV, TGBD, TGKT) values (@MaCV, @MaNV, @TGBD, @TGKT)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddQTL]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddQTL]
@MaNV int,
@MaLuong int, 
@MaPB int, 
@MaCV int, 
@TGBD smalldatetime,
@TGKT smalldatetime
as
	begin
		insert into QUATRINHLUONG(MaNV,MaLuong,MaPB,MaCV,TGBD,TGKT) values (@MaNV,@MaLuong,@MaPB, @MaCV, @TGBD, @TGKT)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddTaiKhoan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddTaiKhoan]
@MaNV int,
@TaiKhoan nvarchar(50),
@MatKhau nvarchar(50),
@LaQuanTri nvarchar(50)

as
	begin
		insert into TAIKHOAN(MaNV, TaiKhoan, MatKhau, LaQuanTri) values (@MaNV, @TaiKhoan, @MatKhau, @LaQuanTri)
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteChucVu]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteChucVu]
@MaCV int
as
begin
	delete from CHUCVU where MaCV=@MaCV
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteHopDong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteHopDong]
@MaHD int
as
begin
	delete from HOPDONG where MaHD=@MaHD
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteKhenThuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteKhenThuong]
@MaKT int
as
begin
	delete from KHENTHUONG where MaKT=@MaKT
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteKyHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteKyHD]
@id int
as
begin
	delete from KYHD where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteKyLuat]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteKyLuat]
@MaKL int
as
begin
	delete from KYLUAT where MaKL=@MaKL
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteLuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteLuong]
@MaLuong int
as
begin
	delete from LUONG where MaLuong=@MaLuong
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteNhanVien]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteNhanVien]
@MaNV int
as
begin
	delete from NHANVIEN where MaNV=@MaNV
end
GO
/****** Object:  StoredProcedure [dbo].[DeletePhongBan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeletePhongBan]
@MaPB int
as
begin
	delete from PHONGBAN where MaPB=@MaPB
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteQTCT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteQTCT]
@id int
as
begin
	delete from QUATRINHCONGTAC where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteQTCV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteQTCV]
@id int
as
begin
	delete from QUATRINHCHUCVU where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteQTL]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteQTL]
@id int
as
begin
	delete from QUATRINHLUONG where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteTaiKhoan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteTaiKhoan]
@id int
as
begin
	delete from TAIKHOAN where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[EditChucVu]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditChucVu]
@MaCV int,
@TenCV nvarchar(50)
as
begin
	update CHUCVU set TenCV = @TenCV
	where MaCV = @MaCV
end
GO
/****** Object:  StoredProcedure [dbo].[EditHopDong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--edit họp đồng
create proc [dbo].[EditHopDong]
@MaHD int,
@ViTri nvarchar(50),
@LoaiHD nvarchar(50),
@ThoiHan nvarchar(50),
@TenHD nvarchar(50)
as
begin
	update HOPDONG set ViTri = @Vitri, LoaiHD = @LoaiHD, ThoiHan = @ThoiHan, TenHD=@TenHD
	where MaHD = @MaHD
end
GO
/****** Object:  StoredProcedure [dbo].[EditKhenThuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditKhenThuong]
@MaKT int,
@ThoiGian smalldatetime,
@QuyetDinh nvarchar(50),
@Sotienthuong nvarchar(50),
@MaNV int
as
begin
	update KHENTHUONG set ThoiGian=@ThoiGian, QuyetDinh=@QuyetDinh, MaNV=@MaNV, Sotienthuong=@Sotienthuong
	where MaKT=@MaKT
end
GO
/****** Object:  StoredProcedure [dbo].[EditKyHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditKyHD]
@id int,
@MaHD int,
@MaNV int,
@NgayKy smalldatetime
as
begin
	update KYHD set MaHD=@MaHD, MaNV=@MaNV, NgayKy=@NgayKy
	where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[EditKyLuat]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditKyLuat]
@MaKL int,
@ThoiGian smalldatetime,
@QuyetDinh nvarchar(50),
@Sotienphat nvarchar(50),
@MaNV int
as
begin
	update KYLUAT set ThoiGian=@ThoiGian, QuyetDinh=@QuyetDinh, Sotienphat=@Sotienphat, MaNV=@MaNV
	where MaKL=@MaKL
end
GO
/****** Object:  StoredProcedure [dbo].[EditLuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditLuong]
@MaLuong int,
@MucLuongCB nvarchar(50)
as
begin
	update LUONG set MucLuongCB=@MucLuongCB
	where MaLuong=@MaLuong
end
GO
/****** Object:  StoredProcedure [dbo].[EditNhanVien]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditNhanVien]
@MaNV int,
@Hoten nvarchar(50),
@Email nvarchar(50),
@SDT nvarchar(11),
@CCCD nvarchar(12),
@Noisinh nvarchar(50),
@Ngaysinh smalldatetime,
@Gioitinh nvarchar(20),
@Diachi nvarchar(100)
as
begin
	update NHANVIEN set Hoten=@Hoten, Email=@Email, SDT=@SDT, CCCD=@CCCD, Noisinh=@Noisinh, Ngaysinh=@Ngaysinh, Gioitinh=@Gioitinh, Diachi=@Diachi
	where MaNV=@MaNV
end
GO
/****** Object:  StoredProcedure [dbo].[EditPhongBan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditPhongBan]
@MaPB int,
@TenPB nvarchar(50)
as
begin
	update PHONGBAN set TenPB=@TenPB
	where MaPB=@MaPB
end
GO
/****** Object:  StoredProcedure [dbo].[EditQTCT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditQTCT]
@id int,
@MaNV int,
@MaPB int,
@TGBD smalldatetime,
@TGKT smalldatetime
as
begin
	update QUATRINHCONGTAC set MaNV=@MaNV, MaPB=@MaPB, TGBD=@TGBD, TGKT=@TGKT
	where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[EditQTCV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditQTCV]
@id int,
@MaCV int,
@MaNV int,
@TGBD smalldatetime,
@TGKT smalldatetime
as
begin
	update QUATRINHCHUCVU set MaCV=@MaCV, MaNV=@MaNV, TGBD=@TGBD, TGKT=@TGKT
	where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[EditQTL]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditQTL]
@id int,
@MaNV int, 
@MaLuong int,
@MaPB int,
@MaCV int,
@TGBD smalldatetime,
@TGKT smalldatetime
as
begin
	update QUATRINHLUONG set MaNV=@MaNV, MaLuong=@MaLuong, MaPB=@MaPB, MaCV=@MaCV, TGBD=@TGBD, TGKT=@TGKT
	where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[EditTaiKhoan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditTaiKhoan]
@id int,
@MaNV int,
@TaiKhoan nvarchar(50),
@MatKhau nvarchar(50),
@LaQuanTri nvarchar(50)
as
begin
	update TAIKHOAN set MaNV=@MaNV , TaiKhoan=@TaiKhoan,MatKhau=@MatKhau, LaQuanTri=@LaQuanTri
	where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetidKyHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetidKyHD]
@id int
as
	select * from KYHD where id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetidQTCT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetidQTCT]
@id int
as
	select * from QUATRINHCONGTAC where id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetidQTCV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetidQTCV]
@id int
as
	select * from QUATRINHCHUCVU where id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetidQTL]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetidQTL]
@id int
as
	select * from QUATRINHLUONG where id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetidTaiKhoan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetidTaiKhoan]
@id int
as
	select * from TAIKHOAN where id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetMaCV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaCV]
@MaCV int
as
	select * from CHUCVU where MaCV=@MaCV
GO
/****** Object:  StoredProcedure [dbo].[GetMaHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaHD]
@MaHD int
as
	select * from HOPDONG where MaHD=@MaHD
GO
/****** Object:  StoredProcedure [dbo].[GetMaKL]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaKL]
@MaKL int
as
	select * from KYLUAT where MaKL=@MaKL
GO
/****** Object:  StoredProcedure [dbo].[GetMaKT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaKT]
@MaKT int
as
	select * from KHENTHUONG where MaKT=@MaKT
GO
/****** Object:  StoredProcedure [dbo].[GetMaLuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaLuong]
@MaLuong int
as
	select * from LUONG where MaLuong=@MaLuong
GO
/****** Object:  StoredProcedure [dbo].[GetMaNV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaNV]
@MaNV int
as
	select * from NHANVIEN where MaNV=@MaNV
GO
/****** Object:  StoredProcedure [dbo].[GetMaPB]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaPB]
@MaPB int
as
	select * from PHONGBAN where MaPB=@MaPB
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachChucVu]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachChucVu] 
as
begin
	select * from CHUCVU order by MaCV DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachHopDong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachHopDong] 
as
begin
	select * from HOPDONG order by MaHD DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachKhenThuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachKhenThuong] 
as
begin
	select * from KHENTHUONG order by MaKT DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachKyHD]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachKyHD] 
as
begin
	select * from KYHD order by id DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachKyLuat]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachKyLuat] 
as
begin
	select * from KYLUAT order by MaKL DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachLuong]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachLuong]
as
begin
	select * from LUONG order by MaLuong DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachNhanVien]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachNhanVien] 
as
begin
	select * from NHANVIEN order by MaNV DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachPhongBan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachPhongBan]
as
begin
	select * from PHONGBAN order by MaPB DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachQTCT]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachQTCT]
as
begin
	select * from QUATRINHCONGTAC order by id DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachQTCV]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachQTCV]
as
begin
	select * from QUATRINHCHUCVU order by id DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachQTL]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachQTL]
as
begin
	select * from QUATRINHLUONG order by id DESC
end
GO
/****** Object:  StoredProcedure [dbo].[ToanBoDanhSachTaiKhoan]    Script Date: 11/20/2022 9:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ToanBoDanhSachTaiKhoan]
as
begin
	select * from TAIKHOAN order by id DESC
end
GO
