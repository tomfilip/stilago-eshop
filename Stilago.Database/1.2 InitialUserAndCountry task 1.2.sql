BEGIN TRAN

DECLARE @userId UNIQUEIDENTIFIER
SET		@userId = NEWID()

DECLARE @countryId UNIQUEIDENTIFIER
SET		@countryId = NEWID()


--Default Countries
INSERT INTO dbo.Country
(Id, Name, Culture)
VALUES
(@countryId, 'United Kingdom', 'en'),
(NEWID(), 'Slovakia', 'sk')

--Default User
INSERT INTO dbo.[User]
(Id, FirstName, LastName, CountryId)
VALUES
(@userId, 'Tomas', 'Filip', @countryId)

--Default Computers
exec sp_executesql N'INSERT [dbo].[Brand]([Id], [Name], [CountryId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(max) ,@2 uniqueidentifier,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='0E270075-6ACE-4FD5-BEE4-DBDBECF09C5E',@1=N'Asus',@2='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@3=0,@4='2015-01-23 01:05:56.2752467 +00:00',@5='2015-01-23 01:05:56.2752467 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Computer]([Id], [Model], [DiskCapacity], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(15),@2 bigint,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='B73C08DE-1991-4DA7-A712-2D84E2A44BE0',@1=N'G751JY-T7009H',@2=5000000,@3=0,@4='2015-01-23 01:05:56.2302632 +00:00',@5='2015-01-23 01:05:56.2302632 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[BrandComputerRelationships]([Id], [ComputerId], [BrandId])
VALUES (@0, @1, @2)
',N'@0 uniqueidentifier,@1 uniqueidentifier,@2 uniqueidentifier',@0='5762D1C5-D37E-4BFB-96A1-11AB7DF9C869',@1='B73C08DE-1991-4DA7-A712-2D84E2A44BE0',@2='0E270075-6ACE-4FD5-BEE4-DBDBECF09C5E'
go
exec sp_executesql N'INSERT [dbo].[ComputerInfo]([Id], [Price], [Description], [CountryId], [ComputerId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)
',N'@0 uniqueidentifier,@1 bigint,@2 nvarchar(max) ,@3 uniqueidentifier,@4 uniqueidentifier,@5 bit,@6 datetimeoffset(7),@7 datetimeoffset(7),@8 uniqueidentifier,@9 uniqueidentifier',@0='83204774-73DF-490C-BC24-7798589BA046',@1=1235,@2=N'Product Description
The G series eye-catching design draws inspiration from stealth fighters, presenting an ergonomically-inclined surface for greater comfort during long gaming sessions. To better keep in touch with your co-op partners and everyone else, there''s an HD camera, while a range of exclusive accessories complete your gaming experiences for more thrills at home and away.
Box Contains
Notebook;Manual;Support Disk;Power Adapter;UK Power Lead',@3='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@4='B73C08DE-1991-4DA7-A712-2D84E2A44BE0',@5=0,@6='2015-01-23 01:05:56.2762654 +00:00',@7='2015-01-23 01:05:56.2762654 +00:00',@8='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@9='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go

exec sp_executesql N'INSERT [dbo].[Brand]([Id], [Name], [CountryId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(max) ,@2 uniqueidentifier,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='FC7BE956-5628-45C9-A651-B7041BEC35CC',@1=N'Acer',@2='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@3=0,@4='2015-01-23 01:08:18.5169515 +00:00',@5='2015-01-23 01:08:18.5169515 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Computer]([Id], [Model], [DiskCapacity], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(15),@2 bigint,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='BA743526-BE70-4459-AD98-D56B84315A12',@1=N'Aspire S7-392',@2=256000,@3=0,@4='2015-01-23 01:08:18.4739512 +00:00',@5='2015-01-23 01:08:18.4739512 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[BrandComputerRelationships]([Id], [ComputerId], [BrandId])
VALUES (@0, @1, @2)
',N'@0 uniqueidentifier,@1 uniqueidentifier,@2 uniqueidentifier',@0='6D4ECDBB-CB84-4ACE-B3F6-B292412203D4',@1='BA743526-BE70-4459-AD98-D56B84315A12',@2='FC7BE956-5628-45C9-A651-B7041BEC35CC'
go
exec sp_executesql N'INSERT [dbo].[ComputerInfo]([Id], [Price], [Description], [CountryId], [ComputerId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)
',N'@0 uniqueidentifier,@1 bigint,@2 nvarchar(max) ,@3 uniqueidentifier,@4 uniqueidentifier,@5 bit,@6 datetimeoffset(7),@7 datetimeoffset(7),@8 uniqueidentifier,@9 uniqueidentifier',@0='45B70217-A1D2-4B51-B36D-5AC4C8CD533A',@1=1595,@2=N'Premium Materials and Construction

Premium Build

The aluminum unibody plus Gorilla Glass 2 design of the Aspire S7 makes it incredibly slender, light and strong. At less than 12.9mm at its thickest, it is an ultra-thin laptop. What''s more, the dual-torque hinge keeps the WQHD touch display very stable when you use it for touch control.

Fast Intel Processor Acer Aspire S7-392 13.3-inch Notebook
Fast Processing with Intel Core Processors

The Aspire S7-392 features a powerful Intel Core i5 or i7 processor for efficient home computing. The Intel Core processor delivers great media processing for fast video editing and sharing, enthusiast class HD video playback, accelerated web browsing, and great mainstream and casual gaming experience.

Quick and Clear

You can work and play faster on the Aspire S7, as it packs a RAID 0 solid state drive (SSD) with up to 2 times faster performance than standard SSDs. Another feature is Acer Purified. Voice technology2 for crystal-clear chats, free of noise.

Acer Aspire S7-392 13.3-inch Notebook
Long Lasting Battery

The Aspire S7 frees you to go all day, with improved battery life of up to 7 hours.1 The light-sensing backlit keyboard auto-optimises its glow so you can see comfortably in dim settings, and it has refined keys2 for better typing. Cool and quiet, 2nd generation Acer TwinAir cooling2 makes this laptop a pleasure to have and to hold.

Touch and Show

The Aspire S7''s WQHD display generates deep detail and puts 10-point touch control at your fingertips. The Aspire S7 is made for teamwork: Open it to 180 degrees, punch a hotkey to flip the view, and you''re in shape to share. Take the show to a big screen, wire-free, via WiDi connectivity.

1Estimated by MobileMark12 (150nits). Battery life varies depending on power settings and usage.
2Available on Aspire S7-392 only.',@3='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@4='BA743526-BE70-4459-AD98-D56B84315A12',@5=0,@6='2015-01-23 01:08:18.5179529 +00:00',@7='2015-01-23 01:08:18.5179529 +00:00',@8='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@9='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Brand]([Id], [Name], [CountryId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(max) ,@2 uniqueidentifier,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='F3C33668-A6AF-4A48-804A-B62EE36E79AF',@1=N'Lenovo',@2='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@3=0,@4='2015-01-23 01:09:53.4698034 +00:00',@5='2015-01-23 01:09:53.4698034 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Computer]([Id], [Model], [DiskCapacity], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(15),@2 bigint,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='CD54DEAF-FC58-400F-9A45-291F51DA6B33',@1=N'X1 Carbon',@2=356000,@3=0,@4='2015-01-23 01:09:53.4268027 +00:00',@5='2015-01-23 01:09:53.4268027 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[BrandComputerRelationships]([Id], [ComputerId], [BrandId])
VALUES (@0, @1, @2)
',N'@0 uniqueidentifier,@1 uniqueidentifier,@2 uniqueidentifier',@0='FA1785BE-FCBC-432A-BFF4-0B28309274F0',@1='CD54DEAF-FC58-400F-9A45-291F51DA6B33',@2='F3C33668-A6AF-4A48-804A-B62EE36E79AF'
go
exec sp_executesql N'INSERT [dbo].[ComputerInfo]([Id], [Price], [Description], [CountryId], [ComputerId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)
',N'@0 uniqueidentifier,@1 bigint,@2 nvarchar(max) ,@3 uniqueidentifier,@4 uniqueidentifier,@5 bit,@6 datetimeoffset(7),@7 datetimeoffset(7),@8 uniqueidentifier,@9 uniqueidentifier',@0='08B0E66C-AE8A-4F0E-9642-C2501624F057',@1=1757,@2=N'Product Description
The new ThinkPad X1 Carbon is thin and light, yet it''s durable; with carbon-fiber construction and packed with premium features like an Adaptive Keyboard that changes automatically with apps, RapidCharge battery technology, a patented cooling system, and a stunning ThinkPad Precision Display.
Box Contains
Lenovo notebook
Battery
AC Adapter
User Documentation/Media',@3='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@4='CD54DEAF-FC58-400F-9A45-291F51DA6B33',@5=0,@6='2015-01-23 01:09:53.4708035 +00:00',@7='2015-01-23 01:09:53.4708035 +00:00',@8='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@9='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Brand]([Id], [Name], [CountryId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(max) ,@2 uniqueidentifier,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='7DAAA201-4275-4137-9391-2C44FE8B66F4',@1=N'Toshiba',@2='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@3=0,@4='2015-01-23 01:11:01.3784549 +00:00',@5='2015-01-23 01:11:01.3784549 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Computer]([Id], [Model], [DiskCapacity], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(15),@2 bigint,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='E1828669-22C6-4667-A0FB-E0A461DAC8D5',@1=N'P50t-B-113',@2=500000,@3=0,@4='2015-01-23 01:11:01.3334513 +00:00',@5='2015-01-23 01:11:01.3334513 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[BrandComputerRelationships]([Id], [ComputerId], [BrandId])
VALUES (@0, @1, @2)
',N'@0 uniqueidentifier,@1 uniqueidentifier,@2 uniqueidentifier',@0='C8D7C82D-1A69-4575-A1C4-930206C53AF0',@1='E1828669-22C6-4667-A0FB-E0A461DAC8D5',@2='7DAAA201-4275-4137-9391-2C44FE8B66F4'
go
exec sp_executesql N'INSERT [dbo].[ComputerInfo]([Id], [Price], [Description], [CountryId], [ComputerId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)
',N'@0 uniqueidentifier,@1 bigint,@2 nvarchar(max) ,@3 uniqueidentifier,@4 uniqueidentifier,@5 bit,@6 datetimeoffset(7),@7 datetimeoffset(7),@8 uniqueidentifier,@9 uniqueidentifier',@0='B84FE2E2-E9BA-4C96-8CD7-69536C53B867',@1=1230,@2=N'With 10-finger touchscreen support, you can interact with your applications and games more intuitively, using all of your fingers -- and get the most out of Windows 8.1 too. The touchscreen is naturally simple to use, and features anti-fingerprint coating, so smudges won''t get in the way of your media as you scroll, drag, swipe or stretch images.

Pure Power

With the Satellite P50-B, you can expect optimum power. The Intel Core i7 processor is Quad Core, so you know it''s going to respond to your every command at speed. Plus, there''s AMD Radeon R9 M265X enthusiast graphics with 2 GB GDDR5 VRAM inside, for a fast, yet smooth graphics performance -- even when playing demanding games, or running multiple applications. When you have this much power within easy reach, you''re ready for anything.

 DTS Studio Sound is an advanced surround sound technology suite developed for PCs, getting the best sound experience possible from your music, movies and games
DTS Studio Sound has a number of features to help you get the best audio experience, including DTS TruVolume and DTS TruBass. Click here to view a larger image.
Hear Every Sound

Lose yourself in higher-quality audio that''s music to your ears. With Harman Kardon stereo speakers and DTS Sound audio enhancement throughout every tune, movie and video. This leading combination of sound enhancement software with premium Harman Kardon speakers provides a listening experience that is more natural and detailed with distinctive dialogue and incredibly immersive surround sound.

High Quality Audio with DTS Studio Sound

DTS Studio Sound is an advanced audio solution suite for all PC applications related to music, movies, streaming and games. Immersive surround with deep, rich bass and crystal clear dialog is delivered at maximum volume levels and without any fluctuations, clipping, or distortion. Speakers and technologies can be tuned for peak performance, and the user''s provided with an intuitive interface providing presets for ease of use.

 Designed to look as good as it performs, The Satellite P50 comes with an eye-catching brushed metal chassis.
Designed to look as good as it performs, The Satellite P50-B comes with an eye-catching brushed metal chassis. Click here to view a larger image.
Manage Your Media

The fully-featured Satellite P50-B lets you do more with your media. You can connect your MP3 player and enjoy your tunes in enriched quality through the premium Harman Kardon stereo speakers. Even if the laptop is off, you can still sink into your favourite sounds using the Sleep-and-Music function.

 The design of the Satellite P50-B includes a brushed aluminium finish with chrome accents, and an illuminated frameless tile keyboard.
The design of the Satellite P50-B includes a brushed aluminium finish with chrome accents, and an illuminated frameless tile keyboard. Click here to view a larger image.
Plug into Flexibility

The Satellite P50-B comes with a range of flexible connectivity options. Just plug it into one of the four USB 3.0 ports to transfer data to and from your device at speed. One of these ports supports Sleep-and-Charge, so you can charge your USB device too, even while your laptop is in sleep mode. Plus, you''re already set-up for your TV -- whether you want to experience lifelike definition on your 3D TV or discover the best image quality available on your Ultra HD capable TV -- all through a HDMI-out port that supports both formats.

HDMI for HD, 3D and 4K Entertainment

The Toshiba Satellite P50-B has an integrated HDMI port for added convenience and enhanced usability. You can connect your laptop to an external device and stream high definition content. When using HDMI, audio and visual content are streamed through a single cable, removing the need for multiple connections. You only need one cable, making connecting your laptop easier and tidier.

 See some of the features of the Toshiba Satellite P50 laptop.
See some of the features of the Toshiba Satellite P50-B laptop. Click here to view a larger image.
Thanks to HDMI technology, when connecting to a compatible display via a HDMI 1.4 cable, you''ll be able to output the very best in 3D entertainment to the big screen. You''ll even be able to experience the next generation of entertainment when pairing this laptop with 4K display.

 See some of the features of the Toshiba Satellite P50 laptop
See some of the features of the Toshiba Satellite P50-B laptop. Click here to view a larger image.
Extensive Wireless Connectivity

The integrated Intel Dual Band Wireless-AC 3160 supports the Wi-Fi AC standard, and takes home networking to another level of reliability, speed and coverage. Bluetooth allows your P50-B to communicate with other Bluetooth-enabled devices. There''s Wireless Display technology too, so you can wirelessly stream all of the things you love -- including music, videos, photos and music -- directly to your big screen HD TV. Plus, there''s Gigabit LAN for the freedom of fast access to your local network.

The McAfee LiveSafe 30-day free trial inc',@3='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@4='E1828669-22C6-4667-A0FB-E0A461DAC8D5',@5=0,@6='2015-01-23 01:11:01.3794761 +00:00',@7='2015-01-23 01:11:01.3794761 +00:00',@8='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@9='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Brand]([Id], [Name], [CountryId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(max) ,@2 uniqueidentifier,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='63F31AA3-6DD4-4571-A69F-1A31EBDDF2B1',@1=N'Gigabyte',@2='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@3=0,@4='2015-01-23 01:12:20.2694676 +00:00',@5='2015-01-23 01:12:20.2694676 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Computer]([Id], [Model], [DiskCapacity], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(15),@2 bigint,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='2EC4EE11-8238-4EDD-B00E-A3654C0D4854',@1=N'P34G V2-CF4',@2=600000,@3=0,@4='2015-01-23 01:12:20.2304863 +00:00',@5='2015-01-23 01:12:20.2304863 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[BrandComputerRelationships]([Id], [ComputerId], [BrandId])
VALUES (@0, @1, @2)
',N'@0 uniqueidentifier,@1 uniqueidentifier,@2 uniqueidentifier',@0='BB17B23F-1D47-4140-803A-DEE3BE51FC21',@1='2EC4EE11-8238-4EDD-B00E-A3654C0D4854',@2='63F31AA3-6DD4-4571-A69F-1A31EBDDF2B1'
go
exec sp_executesql N'INSERT [dbo].[ComputerInfo]([Id], [Price], [Description], [CountryId], [ComputerId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)
',N'@0 uniqueidentifier,@1 bigint,@2 nvarchar(max) ,@3 uniqueidentifier,@4 uniqueidentifier,@5 bit,@6 datetimeoffset(7),@7 datetimeoffset(7),@8 uniqueidentifier,@9 uniqueidentifier',@0='D2ED7279-DAA3-40CA-A8B7-870409F0AF52',@1=999,@2=N'P34G v2 features a speedy NVIDIA GeForce GTX 860M graphics processor that supports NVIDIA FXAA, Adaptive V-Sync technology. NVIDIA GeForce GTX 860M handles higher frame refresh rate with ease and is capable of rendering more detailed graphics when running resource-demanding titles. NVIDIA GeForce GTX 860M, featuring 640 CUDA cores, brings up to 47% performance improvement to its predecessor. P5209 in 3DMARK 11, an impressive score, ensures a solid edge over the gaming competition.
The 4th generation Intel Core Processor delivers breathtaking perforamnce plus improved battery life. New Haswell architecture generates stunning performance without increasing power consumption, achieving excellent power management during system idle. Enjoy breakthrough performance like you''ve never experienced before.

Now P34G v2 pushes this bold innovation further with the latest gaming-level GTX 860M graphics upgrade, along with the 20.9mm, 1.67Kg Ultrabook-like chassis. P34G v2 will definitely keep reining the most powerful laptop in its class.

GIGABYTE exclusive Supra-cool technology features dual heat pipes plus dual fans providing extra protection for CPU & GPU. Upgraded thermal design improves airflow circulation & heat conductivity, ensuring outstanding cooling while remaining slim. The verdict for every GIGABYTE gaming laptop is simple: amazing performance and superb stability.

The 1080p display with great viewing angle up to 170 and 72% NTSC wide color gamut realizes premium',@3='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@4='2EC4EE11-8238-4EDD-B00E-A3654C0D4854',@5=0,@6='2015-01-23 01:12:20.2704686 +00:00',@7='2015-01-23 01:12:20.2704686 +00:00',@8='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@9='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[Computer]([Id], [Model], [DiskCapacity], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7)
',N'@0 uniqueidentifier,@1 nvarchar(15),@2 bigint,@3 bit,@4 datetimeoffset(7),@5 datetimeoffset(7),@6 uniqueidentifier,@7 uniqueidentifier',@0='DB17F326-EB54-42CD-B3D2-188F7D2FAFA7',@1=N'Y70',@2=1000000,@3=0,@4='2015-01-23 01:13:24.3233738 +00:00',@5='2015-01-23 01:13:24.3233738 +00:00',@6='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@7='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go
exec sp_executesql N'INSERT [dbo].[BrandComputerRelationships]([Id], [ComputerId], [BrandId])
VALUES (@0, @1, @2)
',N'@0 uniqueidentifier,@1 uniqueidentifier,@2 uniqueidentifier',@0='596B5945-FFD8-4F0B-B6DD-159B98213B85',@1='DB17F326-EB54-42CD-B3D2-188F7D2FAFA7',@2='F3C33668-A6AF-4A48-804A-B62EE36E79AF'
go
exec sp_executesql N'INSERT [dbo].[ComputerInfo]([Id], [Price], [Description], [CountryId], [ComputerId], [IsDeleted], [CreationTime], [LastModificationTime], [CreatedById], [ModifiedById])
VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)
',N'@0 uniqueidentifier,@1 bigint,@2 nvarchar(max) ,@3 uniqueidentifier,@4 uniqueidentifier,@5 bit,@6 datetimeoffset(7),@7 datetimeoffset(7),@8 uniqueidentifier,@9 uniqueidentifier',@0='C2636762-C88D-499F-BA64-7528A0FC0336',@1=1174,@2=N'Latest Technology - the new Y70 is equipped with the latest Intel Core processor, SSHD storage and powerful Nvidia graphics, meaning that it doesn''t compromise on anything
Full HD Touch display - brings movies, pictures and games to life. Powered by touch technology, you can scroll, swipe and pinch through all your favorite apps
Premium Audio - JBL stereo speakers and subwoofer bring immersive sound when playing music, gaming or watching videos',@3='5D7D785C-6FAB-4E61-A6F5-A31AF9492377',@4='DB17F326-EB54-42CD-B3D2-188F7D2FAFA7',@5=0,@6='2015-01-23 01:13:24.3673867 +00:00',@7='2015-01-23 01:13:24.3673867 +00:00',@8='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4',@9='FECD9A23-5823-4EF1-ADE1-AFF230B7EBB4'
go


COMMIT