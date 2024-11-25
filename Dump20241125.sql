CREATE DATABASE  IF NOT EXISTS `usinsa` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `usinsa`;
-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: usinsa
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `ADDRESS_NUMBER` int NOT NULL AUTO_INCREMENT,
  `CUSTOMER_ID` varchar(10) NOT NULL,
  `ADDRESS_NAME` varchar(10) NOT NULL,
  `ZIP_CODE` varchar(5) NOT NULL,
  `ADDRESS1` varchar(50) NOT NULL,
  `ADDRESS2` varchar(50) NOT NULL,
  `DELETED` char(1) DEFAULT 'N',
  PRIMARY KEY (`ADDRESS_NUMBER`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,'a','기본 주소명','22100','인천광역시 미추홀구 숙골로 113',' (도화동)','N'),(2,'a','추가 주소명','06294','서울특별시 강남구 언주로30길 26',' (도곡동, 타워팰리스)','Y'),(3,'a','','06294','서울특별시 강남구 언주로30길 26',' (도곡동, 타워팰리스)','Y'),(4,'a','추가 주소','06294','서울특별시 강남구 언주로30길 26',' (도곡동, 타워팰리스)','N');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `brand`
--

DROP TABLE IF EXISTS `brand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brand` (
  `BRAND_ID` varchar(20) NOT NULL,
  `BRAND_NAME` varchar(20) NOT NULL,
  `COMPANY_REGIST_NUMBER` char(10) NOT NULL,
  `BRAND_PASSWORD` varchar(20) NOT NULL,
  `LOGO_IMG_PATH` varchar(50) DEFAULT NULL,
  `BRAND_EMAIL1` varchar(20) NOT NULL,
  `BRAND_EMAIL2` varchar(20) NOT NULL,
  `BRAND_CONTACT` varchar(50) DEFAULT NULL,
  `BRAND_ADDRESS` varchar(100) DEFAULT NULL,
  `COUNTRY` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`BRAND_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brand`
--

LOCK TABLES `brand` WRITE;
/*!40000 ALTER TABLE `brand` DISABLE KEYS */;
INSERT INTO `brand` VALUES ('a','에이','12345678','Abcd1234!','../../Images/Logo/a/20241124232507.png','shop1234','E001','https://github.com/Jin0K/GDC8-PersonalProject','',NULL);
/*!40000 ALTER TABLE `brand` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `brand_code`
--

DROP TABLE IF EXISTS `brand_code`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brand_code` (
  `BRAND_ID` varchar(20) NOT NULL,
  `CCODE` char(4) NOT NULL,
  `CATEGORY` varchar(45) NOT NULL,
  `CNAME` varchar(45) NOT NULL,
  `PCODE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`BRAND_ID`,`CCODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brand_code`
--

LOCK TABLES `brand_code` WRITE;
/*!40000 ALTER TABLE `brand_code` DISABLE KEYS */;
INSERT INTO `brand_code` VALUES ('a','C001','색상','검정색',NULL),('a','C002','색상','흰색',NULL),('a','S001','사이즈','S',NULL),('a','S002','사이즈','M',NULL);
/*!40000 ALTER TABLE `brand_code` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `common_code`
--

DROP TABLE IF EXISTS `common_code`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `common_code` (
  `CCODE` char(4) NOT NULL,
  `CATEGORY` varchar(20) NOT NULL,
  `CNAME` varchar(50) NOT NULL,
  `PCODE` char(4) DEFAULT NULL,
  PRIMARY KEY (`CCODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `common_code`
--

LOCK TABLES `common_code` WRITE;
/*!40000 ALTER TABLE `common_code` DISABLE KEYS */;
INSERT INTO `common_code` VALUES ('E001','이메일 주소','naver.com',NULL),('E002','이메일 주소','gmail.com',NULL),('I001','IMG_TYPE','메인 이미지',NULL),('I002','IMG_TYPE','상세 이미지',NULL),('I004','IMG_TYPE_QA','문의 이미지',NULL),('I005','IMG_TYPE_RV','후기 이미지',NULL),('QA01','문의유형','상품문의',NULL),('QA02','문의유형','교환/환불',NULL),('QA03','문의유형','기타',NULL),('SR01','입출고 상태','입고',NULL),('SR02','입출고 상태','출고',NULL),('ST01','주문상태','배송완료',NULL),('ST02','주문상태','배송중',NULL),('ST03','주문상태','결제완료',NULL),('ST04','주문상태','주문완료',NULL),('T100','MAIN_TYPE','의류',NULL),('T110','MIDDLE_TYPE','상의','T100'),('T111','SUB_TYPE','반팔 티셔츠','T110'),('T112','SUB_TYPE','긴팔 티셔츠','T110'),('T113','SUB_TYPE','민소매 티셔츠','T110'),('T114','SUB_TYPE','셔츠/블라우스','T110'),('T115','SUB_TYPE','피케/카라 티셔츠','T110'),('T116','SUB_TYPE','맨투맨/스웨트셔츠','T110'),('T117','SUB_TYPE','후드 티셔츠','T110'),('T118','SUB_TYPE','니트/스웨터','T110'),('T119','SUB_TYPE','기타 상의','T110'),('T130','MIDDLE_TYPE','아우터','T100'),('T131','SUB_TYPE','후드 집업','T130'),('T132','SUB_TYPE','블루종/MA-1','T130'),('T133','SUB_TYPE','레더/라이더스 재킷','T130'),('T134','SUB_TYPE','무스탕/퍼','T130'),('T135','SUB_TYPE','트러커 재킷','T130'),('T136','SUB_TYPE','슈트/블레이저 재킷','T130'),('T137','SUB_TYPE','카디건','T130'),('T138','SUB_TYPE','아노락 재킷','T130'),('T139','SUB_TYPE','플리스/뽀글이','T130'),('T140','SUB_TYPE','트레이닝 재킷','T130'),('T141','SUB_TYPE','스타디움 재킷','T130'),('T142','SUB_TYPE','환절기 코트','T130'),('T143','SUB_TYPE','겨울 코트','T130'),('T144','SUB_TYPE','롱패딩/롱헤비 아우터','T130'),('T145','SUB_TYPE','숏패딩/숏헤비 아우터','T130'),('T146','SUB_TYPE','베스트','T130'),('T147','SUB_TYPE','사파리/헌팅 재킷','T130'),('T148','SUB_TYPE','나일론/코치 재킷','T130'),('T149','SUB_TYPE','기타 아우터','T130'),('T150','MIDDLE_TYPE','바지','T100'),('T151','SUB_TYPE','데님 팬츠','T150'),('T152','SUB_TYPE','코튼 팬츠','T150'),('T153','SUB_TYPE','슈트 팬츠/슬랙스','T150'),('T154','SUB_TYPE','트레이닝/조거 팬츠','T150'),('T155','SUB_TYPE','숏 팬츠','T150'),('T156','SUB_TYPE','레깅스','T150'),('T157','SUB_TYPE','점프 슈트/오버올','T150'),('T158','SUB_TYPE','기타 바지','T150'),('T170','MIDDLE_TYPE','원피스','T100'),('T171','SUB_TYPE','미니 원피스','T170'),('T172','SUB_TYPE','미디 원피스','T170'),('T173','SUB_TYPE','맥시 원피스','T170'),('T190','MIDDLE_TYPE','스커트','T100'),('T191','SUB_TYPE','미니스커트','T190'),('T192','SUB_TYPE','미디스커트','T190'),('T193','SUB_TYPE','롱스커트','T190'),('T200','MAIN_TYPE','신발',NULL),('T210','MIDDLE_TYPE','일상화','T200'),('T211','SUB_TYPE','구두','T210'),('T212','SUB_TYPE','로퍼','T210'),('T213','SUB_TYPE','힐/펌프스','T210'),('T214','SUB_TYPE','플랫 슈즈','T210'),('T215','SUB_TYPE','블로퍼','T210'),('T216','SUB_TYPE','샌들','T210'),('T217','SUB_TYPE','슬리퍼','T210'),('T218','SUB_TYPE','기타 신발','T210'),('T219','SUB_TYPE','모카신/보트 슈즈','T210'),('T220','SUB_TYPE','부츠','T210'),('T221','SUB_TYPE','신발 용품','T210'),('T230','MIDDLE_TYPE','운동화','T200'),('T231','SUB_TYPE','캔버스/단화','T230'),('T232','SUB_TYPE','러닝화/피트니스화','T230'),('T233','SUB_TYPE','농구화','T230'),('T234','SUB_TYPE','기타 스니커즈','T230'),('T300','MAIN_TYPE','가방',NULL),('T310','MIDDLE_TYPE','나들이 가방','T300'),('T311','SUB_TYPE','보스턴/드럼/더플백','T310'),('T312','SUB_TYPE','웨이스트 백','T310'),('T313','SUB_TYPE','파우치 백','T310'),('T314','SUB_TYPE','클러치 백','T310'),('T315','SUB_TYPE','미니 크로스백','T310'),('T316','SUB_TYPE','미니 토트백','T310'),('T317','SUB_TYPE','캐리어','T310'),('T318','SUB_TYPE','가방 소품','T310'),('T330','MIDDLE_TYPE','사무용 가방','T300'),('T331','SUB_TYPE','백팩','T330'),('T332','SUB_TYPE','메신저/크로스 백','T330'),('T333','SUB_TYPE','숄더백','T330'),('T334','SUB_TYPE','토트백','T330'),('T335','SUB_TYPE','에코백','T330'),('T336','SUB_TYPE','브리프케이스','T330'),('T400','MAIN_TYPE','잡화',NULL),('T410','MIDDLE_TYPE','모자','T400'),('T411','SUB_TYPE','캡/야구 모자','T410'),('T412','SUB_TYPE','헌팅캡/베레모','T410'),('T413','SUB_TYPE','페도라','T410'),('T414','SUB_TYPE','버킷/사파리햇','T410'),('T415','SUB_TYPE','비니','T410'),('T416','SUB_TYPE','트루퍼','T410'),('T417','SUB_TYPE','기타 모자','T410'),('T430','MIDDLE_TYPE','양말/레그웨어','T400'),('T431','SUB_TYPE','양말','T430'),('T432','SUB_TYPE','스타킹','T430'),('T450','MIDDLE_TYPE','선글라스/안경테','T400'),('T451','SUB_TYPE','안경','T450'),('T452','SUB_TYPE','선글라스','T450'),('T453','SUB_TYPE','안경 소품','T450'),('T470','MIDDLE_TYPE','지갑/머니클립','T400'),('T471','SUB_TYPE','카드지갑','T470'),('T472','SUB_TYPE','반지갑','T470'),('T473','SUB_TYPE','장지갑','T470'),('T474','SUB_TYPE','중지갑','T470'),('T490','MIDDLE_TYPE','속옷','T400'),('T491','SUB_TYPE','속옷 상의','T490'),('T492','SUB_TYPE','속옷 하의','T490'),('T493','SUB_TYPE','속옷 세트','T490'),('T494','SUB_TYPE','홈웨어','T490'),('T500','MAIN_TYPE','시계/주얼리/그 외',NULL),('T510','MIDDLE_TYPE','시계','T500'),('T511','SUB_TYPE','디지털','T510'),('T512','SUB_TYPE','쿼츠 아날로그','T510'),('T513','SUB_TYPE','오토매틱 아날로그','T510'),('T514','SUB_TYPE','시계 용품','T510'),('T515','SUB_TYPE','기타 시계','T510'),('T530','MIDDLE_TYPE','주얼리','T500'),('T531','SUB_TYPE','팔찌','T530'),('T532','SUB_TYPE','반지','T530'),('T533','SUB_TYPE','목걸이/펜던트','T530'),('T534','SUB_TYPE','귀걸이','T530'),('T535','SUB_TYPE','발찌','T530'),('T536','SUB_TYPE','브로치/배지','T530'),('T537','SUB_TYPE','헤어 액세서리','T530'),('T550','MIDDLE_TYPE','그 외 액세서리','T500'),('T551','SUB_TYPE','마스크','T550'),('T552','SUB_TYPE','키링/키케이스','T550'),('T553','SUB_TYPE','벨트','T550'),('T554','SUB_TYPE','넥타이','T550'),('T555','SUB_TYPE','머플러','T550'),('T556','SUB_TYPE','스카프/반다나','T550'),('T557','SUB_TYPE','장갑','T550'),('T558','SUB_TYPE','기타 액세서리','T550');
/*!40000 ALTER TABLE `common_code` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `CUSTOMER_ID` varchar(10) NOT NULL,
  `CUSTOMER_PASSWORD` varchar(20) NOT NULL,
  `CUSTOMER_NAME` varchar(30) NOT NULL,
  `GENDER` char(1) DEFAULT NULL,
  `BIRTH` date DEFAULT NULL,
  `EMAIL1` varchar(20) NOT NULL,
  `EMAIL2` varchar(20) NOT NULL,
  `PHONE1` varchar(3) NOT NULL,
  `PHONE2` varchar(4) NOT NULL,
  `PHONE3` varchar(4) NOT NULL,
  `ACCUMULATE_POINT` int NOT NULL DEFAULT '0',
  `REGIST_DATE` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ADMIN_DIV` char(1) NOT NULL,
  `BASE_ADDRESS` int DEFAULT NULL,
  PRIMARY KEY (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES ('a','Abcd1234!','에이','F','2024-11-24','abc1234','E001','010','0000','0000',1987,'2024-11-24 22:59:44','C',4);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_detail`
--

DROP TABLE IF EXISTS `order_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_detail` (
  `ORDER_DETAIL_CODE` int NOT NULL AUTO_INCREMENT,
  `ORDER_NUMBER` int NOT NULL,
  `PRODUCT_CODE` int NOT NULL,
  `ORDER_QUANTITY` int NOT NULL,
  PRIMARY KEY (`ORDER_DETAIL_CODE`),
  KEY `fk_order_detail_order_master1_idx` (`ORDER_NUMBER`),
  KEY `fk_order_detail_product1_idx` (`PRODUCT_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_detail`
--

LOCK TABLES `order_detail` WRITE;
/*!40000 ALTER TABLE `order_detail` DISABLE KEYS */;
INSERT INTO `order_detail` VALUES (1,1,1,5);
/*!40000 ALTER TABLE `order_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_master`
--

DROP TABLE IF EXISTS `order_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_master` (
  `ORDER_NUMBER` int NOT NULL AUTO_INCREMENT,
  `CUSTOMER_ID` varchar(10) NOT NULL,
  `ADDRESS_NUMBER` int NOT NULL,
  `ORDER_AMOUNT` int NOT NULL,
  `ORDER_DATETIME` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ORDER_STATUS` char(4) NOT NULL,
  `PAYMENT_CHECK` bit(1) NOT NULL,
  PRIMARY KEY (`ORDER_NUMBER`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_master`
--

LOCK TABLES `order_master` WRITE;
/*!40000 ALTER TABLE `order_master` DISABLE KEYS */;
INSERT INTO `order_master` VALUES (1,'a',4,198750,'2024-11-25 22:12:32','ST03',_binary '');
/*!40000 ALTER TABLE `order_master` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `PRODUCT_CODE` int NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(20) NOT NULL,
  `PRODUCT_DESCRIPTION` text,
  `PRICE` int NOT NULL,
  `SIZE` char(4) NOT NULL,
  `COLOR` char(4) NOT NULL,
  `INVENTORY` int NOT NULL,
  `MAIN_CATEGORY` char(4) NOT NULL,
  `MIDDLE_CATEGORY` char(4) NOT NULL,
  `SUB_CATEGORY` char(4) NOT NULL,
  `BRAND_ID` varchar(20) NOT NULL,
  `DISCOUNT_RATE` float DEFAULT NULL,
  `REGIST_DATETIME` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PRODUCT_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'에이후드','A급 후드',53000,'S001','C001',0,'T100','T110','T117','a',0.25,'2024-11-24 23:30:26'),(2,'에이후드','A급 후드',53000,'S001','C002',50,'T100','T110','T117','a',0.25,'2024-11-24 23:30:27'),(3,'에이후드','A급 후드',53000,'S002','C001',100,'T100','T110','T117','a',0.25,'2024-11-24 23:30:27'),(4,'에이후드','A급 후드',53000,'S002','C002',1,'T100','T110','T117','a',0.25,'2024-11-24 23:30:27');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_img`
--

DROP TABLE IF EXISTS `product_img`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_img` (
  `PRODUCT_IMG_CODE` int NOT NULL AUTO_INCREMENT,
  `PRODUCT_CODE` int NOT NULL,
  `SERVER_PATH` varchar(250) NOT NULL,
  `IMG_DIV` char(4) NOT NULL,
  `CONTACT_NUMBER` int DEFAULT NULL,
  `REVIEW_NUMBER` int DEFAULT NULL,
  PRIMARY KEY (`PRODUCT_IMG_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_img`
--

LOCK TABLES `product_img` WRITE;
/*!40000 ALTER TABLE `product_img` DISABLE KEYS */;
INSERT INTO `product_img` VALUES (1,1,'../../Images/Product/a/1_20241124233026.png','I002',NULL,NULL),(2,1,'../../Images/Product/a/1_20241124233027.jpg','I002',NULL,NULL),(3,2,'../../Images/Product/a/2_20241124233027.jpg','I001',NULL,NULL),(4,2,'../../Images/Product/a/2_20241124233027.png','I002',NULL,NULL),(5,1,'../../Images/QandA/a/20241125222944946.jpg','I004',2,NULL),(6,1,'../../Images/QandA/a/20241125222945249.jpg','I004',2,NULL),(7,1,'../../Images/Review/a/20241125223058368.jpg','I005',NULL,1);
/*!40000 ALTER TABLE `product_img` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `q_and_a`
--

DROP TABLE IF EXISTS `q_and_a`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `q_and_a` (
  `CONTACT_NUMBER` int NOT NULL AUTO_INCREMENT,
  `CUSTOMER_ID` varchar(10) NOT NULL,
  `PRODUCT_CODE` int NOT NULL,
  `QUESTION_TYPE` char(4) NOT NULL,
  `TITLE` varchar(50) NOT NULL,
  `CONTENTS` text NOT NULL,
  `SECRET` bit(1) NOT NULL,
  `HITS` int NOT NULL DEFAULT '0',
  `REGIST_DATETIME` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ANSWER` text,
  `ANSWER_DATETIME` datetime DEFAULT NULL,
  `DELETED` bit(1) DEFAULT b'0',
  PRIMARY KEY (`CONTACT_NUMBER`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `q_and_a`
--

LOCK TABLES `q_and_a` WRITE;
/*!40000 ALTER TABLE `q_and_a` DISABLE KEYS */;
INSERT INTO `q_and_a` VALUES (1,'a',1,'QA01','언제 재입고 되나요?','상품을 구매하고 싶은데 품절이네요.',_binary '',1,'2024-11-25 22:17:36',NULL,NULL,_binary '\0'),(2,'a',1,'QA02','다른 제품이 왔어요.','후드티대신 셔츠가 왔어요',_binary '\0',0,'2024-11-25 22:29:47',NULL,NULL,_binary '\0');
/*!40000 ALTER TABLE `q_and_a` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `review`
--

DROP TABLE IF EXISTS `review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `review` (
  `REVIEW_NUMBER` int NOT NULL AUTO_INCREMENT,
  `ORDER_DETAIL_CODE` int NOT NULL,
  `TITLE` varchar(50) NOT NULL,
  `CONTENTS` text,
  `SCORE` float NOT NULL,
  `REGIST_DATETIME` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DELETED` bit(1) DEFAULT b'0',
  `HITS` int DEFAULT '0',
  PRIMARY KEY (`REVIEW_NUMBER`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `review`
--

LOCK TABLES `review` WRITE;
/*!40000 ALTER TABLE `review` DISABLE KEYS */;
INSERT INTO `review` VALUES (1,1,'무난하게 잘 입을 것 같아요','예뻐요',4,'2024-11-25 22:31:01',_binary '\0',1);
/*!40000 ALTER TABLE `review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shopping_cart`
--

DROP TABLE IF EXISTS `shopping_cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shopping_cart` (
  `SHOPPING_CART_ID` int NOT NULL AUTO_INCREMENT,
  `CUSTOMER_ID` varchar(10) NOT NULL,
  `PRODUCT_CODE` int NOT NULL,
  `QUANTITY` int NOT NULL,
  `INCLUDED_DATE` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ORDER_CHECK` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`SHOPPING_CART_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shopping_cart`
--

LOCK TABLES `shopping_cart` WRITE;
/*!40000 ALTER TABLE `shopping_cart` DISABLE KEYS */;
INSERT INTO `shopping_cart` VALUES (1,'a',2,1,'2024-11-25 22:32:06',_binary '\0'),(2,'a',3,2,'2024-11-25 22:32:18',_binary '\0');
/*!40000 ALTER TABLE `shopping_cart` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-25 23:47:19
