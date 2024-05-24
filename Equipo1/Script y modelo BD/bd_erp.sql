CREATE DATABASE  IF NOT EXISTS `bd_erp` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bd_erp`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bd_erp
-- ------------------------------------------------------
-- Server version	8.1.0

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
-- Table structure for table `moneda`
--

DROP TABLE IF EXISTS `moneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `moneda` (
  `idmoneda` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `estado` varchar(50) DEFAULT NULL,
  `pais_origen` varchar(100) DEFAULT NULL,
  `simbolo` varchar(10) NOT NULL,
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`idmoneda`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moneda`
--

LOCK TABLES `moneda` WRITE;
/*!40000 ALTER TABLE `moneda` DISABLE KEYS */;
INSERT INTO `moneda` VALUES (1,'Quetzales','Activo','guatemala','Q','2024-05-11'),(2,'Dólar','Activo','USA','$','2024-05-11'),(3,'Euros','Activo','España','€','2024-05-11');
/*!40000 ALTER TABLE `moneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_aplicaciones`
--

DROP TABLE IF EXISTS `tbl_aplicaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_aplicaciones` (
  `pk_id_aplicacion` int NOT NULL,
  `nombre_aplicacion` varchar(50) NOT NULL,
  `descripcion_aplicacion` varchar(150) NOT NULL,
  `estado_aplicacion` tinyint DEFAULT '0',
  PRIMARY KEY (`pk_id_aplicacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_aplicaciones`
--

LOCK TABLES `tbl_aplicaciones` WRITE;
/*!40000 ALTER TABLE `tbl_aplicaciones` DISABLE KEYS */;
INSERT INTO `tbl_aplicaciones` VALUES (1,'Menu','Ingreso Login',1),(999,'Cerrar Sesion','Cerrar Sesion',1),(1000,'MDI SEGURIDAD','PARA SEGURIDAD',1),(1001,'Mant. Usuario','PARA SEGURIDAD',1),(1002,'Mant. Aplicación','PARA SEGURIDAD',1),(1003,'Mant. Modulo','PARA SEGURIDAD',1),(1004,'Mant. Perfil','PARA SEGURIDAD',1),(1101,'Asign. Modulo Aplicacion','PARA SEGURIDAD',1),(1102,'Asign. Aplicacion Perfil','PARA SEGURIDAD',1),(1103,'Asign. Perfil Usuario','PARA SEGURIDAD',1),(1201,'Pcs. Cambio Contraseña','PARA SEGURIDAD',1),(1301,'Pcs. BITACORA','PARA SEGURIDAD',1),(8000,'MDI PROTOTIPO ERP','PARA ERP',1),(8001,'Mant. Proveedor','PARA ERP',1),(8002,'Mant. Transacciones Proveedor','PARA ERP',1),(8003,'Mant. Clientes','PARA ERP',1),(8004,'Mant. Vendedores','PARA ERP',1),(8005,'Mant. Productos','PARA ERP',1),(8006,'Mant. Mov. Inventario','PARA ERP',1),(8007,'Mant. Bancos','PARA ERP',1),(8008,'Mant. Movimiento Bancos','PARA ERP',1),(8009,'Mant. Tipo de Cambio','PARA ERP',1),(8010,'Pro. Ordenes de Compra','PARA ERP',1),(8011,'Pro. Compras','PARA ERP',1),(8012,'Pro. Factura por Pagar','PARA ERP',1),(8013,'Pro. Operaciones Proveedores','PARA ERP',1),(8014,'Pro. Cotizacion de Ventas','PARA ERP',1),(8015,'Pro. Pedidos','PARA ERP',1),(8016,'Pro. Facturas por Cobrar','PARA ERP',1),(8017,'Pro. Traslado de Producto','PARA ERP',1),(8018,'Pro. Auditoría de Inventario','PARA ERP',1),(8019,'Pro. Movimiento Bancario','PARA ERP',1),(8020,'Pro. Autorizacion Ordenes','PARA ERP',1),(8021,'Pro. Disponibilidad Diaria','PARA ERP',1),(8022,'Registro Marcas','PARA ERP',1),(8023,'Registro Líneas','PARA ERP',1),(8024,'Mant. Sucursales','PARA ERP',1),(8030,'Mant. Cuenta bancaria','PARA ERP',1),(8031,'Pro. Movimiento de bancos','PARA ERP',1),(8034,'Pro. Disponibilidad Diaria','PARA ERP',1),(8035,'Pro. Tipo de cambio','PARA ERP',1);
/*!40000 ALTER TABLE `tbl_aplicaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_asignacionesperfilsusuario`
--

DROP TABLE IF EXISTS `tbl_asignacionesperfilsusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_asignacionesperfilsusuario` (
  `fk_id_usuario` int NOT NULL,
  `fk_id_perfil` int NOT NULL,
  PRIMARY KEY (`fk_id_usuario`,`fk_id_perfil`),
  KEY `fk_id_perfil` (`fk_id_perfil`),
  CONSTRAINT `tbl_asignacionesperfilsusuario_ibfk_1` FOREIGN KEY (`fk_id_usuario`) REFERENCES `tbl_usuarios` (`pk_id_usuario`),
  CONSTRAINT `tbl_asignacionesperfilsusuario_ibfk_2` FOREIGN KEY (`fk_id_perfil`) REFERENCES `tbl_perfiles` (`pk_id_perfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_asignacionesperfilsusuario`
--

LOCK TABLES `tbl_asignacionesperfilsusuario` WRITE;
/*!40000 ALTER TABLE `tbl_asignacionesperfilsusuario` DISABLE KEYS */;
INSERT INTO `tbl_asignacionesperfilsusuario` VALUES (1,1);
/*!40000 ALTER TABLE `tbl_asignacionesperfilsusuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_asignacionmoduloaplicacion`
--

DROP TABLE IF EXISTS `tbl_asignacionmoduloaplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_asignacionmoduloaplicacion` (
  `fk_id_modulos` int NOT NULL,
  `fk_id_aplicacion` int NOT NULL,
  PRIMARY KEY (`fk_id_modulos`,`fk_id_aplicacion`),
  KEY `fk_id_aplicacion` (`fk_id_aplicacion`),
  CONSTRAINT `tbl_asignacionmoduloaplicacion_ibfk_1` FOREIGN KEY (`fk_id_modulos`) REFERENCES `tbl_modulos` (`pk_id_modulos`),
  CONSTRAINT `tbl_asignacionmoduloaplicacion_ibfk_2` FOREIGN KEY (`fk_id_aplicacion`) REFERENCES `tbl_aplicaciones` (`pk_id_aplicacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_asignacionmoduloaplicacion`
--

LOCK TABLES `tbl_asignacionmoduloaplicacion` WRITE;
/*!40000 ALTER TABLE `tbl_asignacionmoduloaplicacion` DISABLE KEYS */;
INSERT INTO `tbl_asignacionmoduloaplicacion` VALUES (1000,1000),(1000,1001),(1000,1002),(1000,1003),(1000,1004),(1000,1102),(1000,1103),(1000,1201),(1000,1301),(8000,8000),(8000,8001),(8000,8002),(8000,8003),(8000,8004),(8000,8005),(8000,8006),(8000,8007),(8000,8008),(8000,8009),(8000,8010),(8000,8011),(8000,8012),(8000,8013),(8000,8014),(8000,8015),(8000,8016),(8000,8017),(8000,8018),(8000,8019),(8000,8020),(8000,8021),(8000,8022),(8000,8023),(8000,8024),(8000,8030),(8000,8031);
/*!40000 ALTER TABLE `tbl_asignacionmoduloaplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_autorizacionordenescompra`
--

DROP TABLE IF EXISTS `tbl_autorizacionordenescompra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_autorizacionordenescompra` (
  `id_numeroDeAutorizacion` int NOT NULL AUTO_INCREMENT,
  `tbl_OrdenesCompra_id_OrdComp` int NOT NULL,
  `estadoOrden` varchar(30) NOT NULL,
  `conceptoDeAutorizacion` varchar(50) NOT NULL,
  `fechaAutorizacion` date NOT NULL,
  `subTotal` double NOT NULL,
  `iva` double NOT NULL,
  `totalOrden` double NOT NULL,
  `cuentaAsociada` int NOT NULL,
  PRIMARY KEY (`id_numeroDeAutorizacion`),
  KEY `tbl_OrdenesCompra_id_OrdComp` (`tbl_OrdenesCompra_id_OrdComp`),
  KEY `cuentaAsociada` (`cuentaAsociada`),
  CONSTRAINT `tbl_autorizacionordenescompra_ibfk_1` FOREIGN KEY (`tbl_OrdenesCompra_id_OrdComp`) REFERENCES `tbl_ordenescompra` (`id_OrdComp`),
  CONSTRAINT `tbl_autorizacionordenescompra_ibfk_2` FOREIGN KEY (`cuentaAsociada`) REFERENCES `tbl_cuentabancaria` (`id_cuentaBancaria`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_autorizacionordenescompra`
--

LOCK TABLES `tbl_autorizacionordenescompra` WRITE;
/*!40000 ALTER TABLE `tbl_autorizacionordenescompra` DISABLE KEYS */;
INSERT INTO `tbl_autorizacionordenescompra` VALUES (1,1,'Aprobado','Esta persona debe mucho dinero ','2024-04-26',500.2,15.2,515.2,1),(2,3,'Aprobado','Se aprueba [modificado]','2024-04-26',90700,10884,101584,1),(4,7,'Aprobado','El saldo de la cuenta cubre el total de la orden','2024-05-18',5369,644.280000000001,6013.28,1),(5,1,'Aprobado','El saldo de la cuenta cubre el total de la orden','2024-04-05',500.2,15.2,515.2,1),(6,1,'Aprobado','El saldo de la cuenta cubre el total de la orden','2024-04-05',500.2,15.2,515.2,1),(7,71,'Aprobado','El saldo de la cuenta cubre el total de la orden','2024-05-23',400000,48000,448000,2);
/*!40000 ALTER TABLE `tbl_autorizacionordenescompra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_banco`
--

DROP TABLE IF EXISTS `tbl_banco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_banco` (
  `id_banco` int NOT NULL AUTO_INCREMENT,
  `nombre_banco` varchar(30) NOT NULL,
  `direccion_banco` varchar(50) DEFAULT NULL,
  `telefono_banco` varchar(20) DEFAULT NULL,
  `estado_banco` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_banco`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_banco`
--

LOCK TABLES `tbl_banco` WRITE;
/*!40000 ALTER TABLE `tbl_banco` DISABLE KEYS */;
INSERT INTO `tbl_banco` VALUES (3,'Banco Industrial','zona2','142412','Activo '),(4,'BAM','zona3','87656278','Suspendido');
/*!40000 ALTER TABLE `tbl_banco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_bitacoradeeventos`
--

DROP TABLE IF EXISTS `tbl_bitacoradeeventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_bitacoradeeventos` (
  `pk_id_bitacora` int NOT NULL AUTO_INCREMENT,
  `fk_id_usuario` int NOT NULL,
  `fk_id_aplicacion` int NOT NULL,
  `fecha_bitacora` date NOT NULL,
  `hora_bitacora` time NOT NULL,
  `host_bitacora` varchar(45) NOT NULL,
  `ip_bitacora` varchar(100) NOT NULL,
  `accion_bitacora` varchar(50) NOT NULL,
  PRIMARY KEY (`pk_id_bitacora`),
  KEY `fk_id_usuario` (`fk_id_usuario`),
  KEY `fk_id_aplicacion` (`fk_id_aplicacion`),
  CONSTRAINT `tbl_bitacoradeeventos_ibfk_1` FOREIGN KEY (`fk_id_usuario`) REFERENCES `tbl_usuarios` (`pk_id_usuario`),
  CONSTRAINT `tbl_bitacoradeeventos_ibfk_2` FOREIGN KEY (`fk_id_aplicacion`) REFERENCES `tbl_aplicaciones` (`pk_id_aplicacion`)
) ENGINE=InnoDB AUTO_INCREMENT=1058 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_bitacoradeeventos`
--

LOCK TABLES `tbl_bitacoradeeventos` WRITE;
/*!40000 ALTER TABLE `tbl_bitacoradeeventos` DISABLE KEYS */;
INSERT INTO `tbl_bitacoradeeventos` VALUES (1,1,1000,'2024-02-21','19:21:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(2,1,1000,'2024-02-21','19:21:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(3,1,1,'2024-02-23','08:36:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(4,1,1000,'2024-02-23','08:36:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(5,1,1,'2024-02-23','08:37:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(6,1,1,'2024-02-23','08:37:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(7,1,999,'2024-02-23','08:37:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Cerro Sesion'),(8,1,1,'2024-02-23','09:12:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(9,1,1000,'2024-02-23','09:12:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(10,1,1000,'2024-02-23','09:14:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(11,1,999,'2024-02-23','09:27:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Cerro Sesion'),(12,1,1,'2024-02-23','21:23:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(13,1,1000,'2024-02-23','21:23:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(14,1,1000,'2024-02-23','21:24:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(15,1,1000,'2024-02-23','21:25:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(16,1,1,'2024-02-23','21:26:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(17,1,1000,'2024-02-23','21:26:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(18,1,1,'2024-02-23','21:28:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(19,1,1000,'2024-02-23','21:28:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(20,1,1000,'2024-02-23','21:29:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(21,1,1000,'2024-02-23','21:30:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(22,1,999,'2024-02-23','21:54:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Cerro Sesion'),(23,1,1,'2024-04-10','20:28:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(24,1,1000,'2024-04-10','20:28:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(25,1,1000,'2024-04-10','20:29:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(26,1,1000,'2024-04-10','20:29:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(27,1,1000,'2024-04-10','20:29:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(28,1,1000,'2024-04-10','20:29:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(29,1,1,'2024-04-10','20:41:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(30,1,1000,'2024-04-10','20:41:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(31,1,1,'2024-04-10','20:43:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(32,1,1000,'2024-04-10','20:43:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(33,1,1,'2024-04-10','20:45:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(34,1,1000,'2024-04-10','20:45:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(35,1,1,'2024-04-10','20:46:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(36,1,1000,'2024-04-10','20:46:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(37,1,1,'2024-04-10','20:47:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(38,1,1000,'2024-04-10','20:47:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(39,1,1,'2024-04-10','22:32:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(40,1,1000,'2024-04-10','22:32:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(41,1,1,'2024-04-10','22:33:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(42,1,1000,'2024-04-10','22:33:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(43,1,1,'2024-04-10','22:40:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(44,1,1000,'2024-04-10','22:40:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(45,1,1,'2024-04-10','22:42:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(46,1,1000,'2024-04-10','22:42:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(47,1,1,'2024-04-10','22:44:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(48,1,1000,'2024-04-10','22:44:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(49,1,1,'2024-04-10','22:45:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(50,1,1000,'2024-04-10','22:45:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(51,1,1,'2024-04-10','22:48:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(52,1,1000,'2024-04-10','22:48:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(53,1,1,'2024-04-10','22:49:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(54,1,1000,'2024-04-10','22:49:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(55,1,1,'2024-04-10','22:50:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(56,1,1000,'2024-04-10','22:50:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(57,1,1,'2024-04-10','22:52:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(58,1,1000,'2024-04-10','22:52:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(59,1,1,'2024-04-10','22:58:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(60,1,1000,'2024-04-10','22:58:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(61,1,1,'2024-04-10','22:59:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(62,1,1000,'2024-04-10','22:59:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(63,1,1000,'2024-04-10','23:01:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(64,1,1,'2024-04-10','23:02:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(65,1,1000,'2024-04-10','23:02:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(66,1,1,'2024-04-10','23:05:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(67,1,1000,'2024-04-10','23:05:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(68,1,1,'2024-04-10','23:06:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(69,1,1000,'2024-04-10','23:06:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(70,1,1,'2024-04-10','23:06:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(71,1,1000,'2024-04-10','23:06:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(72,1,1,'2024-04-10','23:09:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(73,1,1000,'2024-04-10','23:09:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(74,1,1,'2024-04-10','23:10:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(75,1,1000,'2024-04-10','23:10:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(76,1,1,'2024-04-10','23:11:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(77,1,1000,'2024-04-10','23:11:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(78,1,1,'2024-04-10','23:13:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(79,1,1000,'2024-04-10','23:13:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(80,1,1,'2024-04-10','23:16:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(81,1,1000,'2024-04-10','23:16:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(82,1,1,'2024-04-10','23:25:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(83,1,1000,'2024-04-10','23:25:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(84,1,1,'2024-04-10','23:27:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(85,1,1000,'2024-04-10','23:27:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(86,1,1,'2024-04-10','23:28:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(87,1,1000,'2024-04-10','23:28:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(88,1,1,'2024-04-10','23:31:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(89,1,1000,'2024-04-10','23:31:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(90,1,1,'2024-04-10','23:31:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(91,1,1000,'2024-04-10','23:32:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(92,1,1,'2024-04-10','23:34:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(93,1,1000,'2024-04-10','23:34:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(94,1,1,'2024-04-10','23:35:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(95,1,1000,'2024-04-10','23:35:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(96,1,1,'2024-04-10','23:37:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(97,1,1000,'2024-04-10','23:37:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(98,1,1,'2024-04-10','23:39:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(99,1,1000,'2024-04-10','23:39:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(100,1,1,'2024-04-10','23:52:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(101,1,1000,'2024-04-10','23:52:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(102,1,1,'2024-04-10','23:53:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(103,1,1000,'2024-04-10','23:54:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(104,1,1,'2024-04-10','23:54:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(105,1,1000,'2024-04-10','23:54:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(106,1,1,'2024-04-10','23:56:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(107,1,1000,'2024-04-10','23:56:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(108,1,1,'2024-04-11','09:43:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(109,1,1000,'2024-04-11','09:43:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(111,1,1000,'2024-04-11','09:43:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(112,1,1,'2024-04-11','09:44:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(113,1,1000,'2024-04-11','09:44:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(114,1,1000,'2024-04-11','09:44:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(115,1,1000,'2024-04-11','09:44:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(116,1,1,'2024-04-11','09:47:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(117,1,1000,'2024-04-11','09:47:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(119,1,1000,'2024-04-11','09:47:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(120,1,1,'2024-04-11','09:50:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(121,1,1000,'2024-04-11','09:50:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(122,1,1,'2024-04-11','09:53:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(123,1,1000,'2024-04-11','09:53:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(124,1,1,'2024-04-11','16:43:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(125,1,1,'2024-04-11','16:45:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(126,1,8000,'2024-04-11','16:45:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(127,1,1,'2024-04-11','16:47:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(128,1,8000,'2024-04-11','16:47:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(129,1,1,'2024-04-11','16:59:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(130,1,8000,'2024-04-11','16:59:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(131,1,1,'2024-04-11','17:01:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(132,1,8000,'2024-04-11','17:01:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(133,1,8000,'2024-04-11','17:01:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(134,1,1,'2024-04-11','17:20:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(135,1,8000,'2024-04-11','17:20:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(136,1,1,'2024-04-11','17:22:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(137,1,8000,'2024-04-11','17:22:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(138,1,1,'2024-04-11','17:23:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(139,1,8000,'2024-04-11','17:23:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(140,1,1,'2024-04-11','17:29:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(141,1,8000,'2024-04-11','17:29:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(142,1,1,'2024-04-11','17:30:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(143,1,8000,'2024-04-11','17:30:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(144,1,1,'2024-04-11','17:32:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(145,1,8000,'2024-04-11','17:32:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(146,1,1,'2024-04-11','17:33:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(147,1,8000,'2024-04-11','17:33:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(148,1,1,'2024-04-11','17:35:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(149,1,8000,'2024-04-11','17:35:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(150,1,1,'2024-04-11','17:41:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(151,1,8000,'2024-04-11','17:41:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(152,1,1,'2024-04-11','17:42:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(153,1,8000,'2024-04-11','17:42:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(154,1,1,'2024-04-11','17:45:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(155,1,8000,'2024-04-11','17:45:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(156,1,8000,'2024-04-11','17:45:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(157,1,1,'2024-04-11','18:31:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(158,1,8000,'2024-04-11','18:32:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(159,1,1,'2024-04-11','18:40:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(160,1,8000,'2024-04-11','18:40:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(161,1,1,'2024-04-11','19:02:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(162,1,8000,'2024-04-11','19:02:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(163,1,1,'2024-04-11','19:39:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(164,1,8000,'2024-04-11','19:39:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(165,1,1,'2024-04-11','19:40:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(166,1,8000,'2024-04-11','19:40:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(167,1,1,'2024-04-11','20:00:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(168,1,8000,'2024-04-11','20:00:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(169,1,1,'2024-04-11','20:01:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(170,1,8000,'2024-04-11','20:01:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(171,1,1,'2024-04-11','20:03:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(172,1,8000,'2024-04-11','20:03:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(173,1,1,'2024-04-11','20:05:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(174,1,8000,'2024-04-11','20:05:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(175,1,1,'2024-04-11','20:19:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(176,1,8000,'2024-04-11','20:19:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(177,1,1,'2024-04-11','20:21:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(178,1,8000,'2024-04-11','20:21:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(179,1,1,'2024-04-11','20:22:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(180,1,8000,'2024-04-11','20:22:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(181,1,1,'2024-04-11','20:24:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(182,1,8000,'2024-04-11','20:24:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(183,1,1,'2024-04-11','20:29:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(184,1,8000,'2024-04-11','20:29:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(185,1,1,'2024-04-11','20:31:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(186,1,8000,'2024-04-11','20:31:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(187,1,1,'2024-04-11','20:34:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(188,1,8000,'2024-04-11','20:34:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(189,1,1,'2024-04-11','20:36:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(190,1,8000,'2024-04-11','20:37:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(191,1,1,'2024-04-11','20:39:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(192,1,8000,'2024-04-11','20:39:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(193,1,1,'2024-04-11','20:44:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(194,1,8000,'2024-04-11','20:44:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(195,1,1,'2024-04-11','20:46:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(196,1,8000,'2024-04-11','20:46:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(197,1,1,'2024-04-11','20:48:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(198,1,8000,'2024-04-11','20:48:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(199,1,1,'2024-04-11','20:49:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(200,1,8000,'2024-04-11','20:49:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(201,1,1,'2024-04-11','20:56:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(202,1,8000,'2024-04-11','20:56:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(203,1,1,'2024-04-11','21:07:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(204,1,8000,'2024-04-11','21:07:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(205,1,8003,'2024-04-11','21:07:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(206,1,1000,'2024-04-11','21:07:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(207,1,1,'2024-04-12','08:59:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(208,1,8000,'2024-04-12','08:59:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(209,1,1,'2024-04-12','09:09:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(210,1,8000,'2024-04-12','09:09:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(211,1,1,'2024-04-12','09:11:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(212,1,8000,'2024-04-12','09:11:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(213,1,1,'2024-04-12','10:06:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(214,1,8000,'2024-04-12','10:06:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(215,1,8003,'2024-04-12','10:08:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(216,1,8003,'2024-04-12','10:09:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(217,1,8003,'2024-04-12','10:09:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(218,1,8004,'2024-04-12','10:09:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(219,1,1,'2024-04-12','10:17:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(220,1,8000,'2024-04-12','10:17:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(221,1,1,'2024-04-12','10:19:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(222,1,8000,'2024-04-12','10:19:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(223,1,1,'2024-04-12','10:21:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(224,1,8000,'2024-04-12','10:21:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(225,1,1,'2024-04-12','10:23:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(226,1,8000,'2024-04-12','10:23:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(227,1,1,'2024-04-12','10:24:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(228,1,8000,'2024-04-12','10:24:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(229,1,1,'2024-04-12','10:25:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(230,1,8000,'2024-04-12','10:25:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(231,1,1,'2024-04-12','10:31:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(232,1,8000,'2024-04-12','10:31:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(233,1,1,'2024-04-12','10:36:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(234,1,8000,'2024-04-12','10:36:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(235,1,1,'2024-04-12','10:36:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(236,1,8000,'2024-04-12','10:36:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(237,1,1,'2024-04-12','10:38:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(238,1,8000,'2024-04-12','10:38:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(239,1,1,'2024-04-12','10:40:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(240,1,8000,'2024-04-12','10:40:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(241,1,1,'2024-04-12','10:45:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(242,1,8000,'2024-04-12','10:45:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(243,1,1,'2024-04-12','10:47:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(244,1,8000,'2024-04-12','10:47:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(245,1,1,'2024-04-12','10:47:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(246,1,8000,'2024-04-12','10:47:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(247,1,1,'2024-04-12','10:58:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(248,1,8000,'2024-04-12','10:58:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(249,1,1,'2024-04-12','11:25:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(250,1,8000,'2024-04-12','11:25:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(251,1,1,'2024-04-12','11:49:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(252,1,8000,'2024-04-12','11:49:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(253,1,1,'2024-04-12','11:50:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(254,1,8000,'2024-04-12','11:50:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(255,1,1,'2024-04-12','11:52:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(256,1,8000,'2024-04-12','11:52:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(257,1,8001,'2024-04-12','11:52:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(258,1,8001,'2024-04-12','11:52:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(259,1,8001,'2024-04-12','11:52:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(260,1,8001,'2024-04-12','11:53:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(261,1,8001,'2024-04-12','11:53:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(262,1,8001,'2024-04-12','11:53:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(263,1,8001,'2024-04-12','11:53:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha eliminado un registro'),(264,1,8001,'2024-04-12','11:53:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha eliminado un registro'),(265,1,8001,'2024-04-12','11:53:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(266,1,8003,'2024-04-12','11:54:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(267,1,8001,'2024-04-12','11:55:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(268,1,1,'2024-04-12','11:56:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(269,1,8000,'2024-04-12','11:56:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(270,1,8001,'2024-04-12','11:56:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(271,1,8001,'2024-04-12','11:56:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(272,1,8001,'2024-04-12','11:56:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(273,1,8001,'2024-04-12','11:56:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(274,1,1,'2024-04-12','13:12:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(275,1,8000,'2024-04-12','13:12:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(276,1,1,'2024-04-12','13:13:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(277,1,8000,'2024-04-12','13:13:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(278,1,8004,'2024-04-12','13:14:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(279,1,1,'2024-04-12','13:15:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(280,1,8000,'2024-04-12','13:15:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(281,1,8004,'2024-04-12','13:16:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(282,1,8004,'2024-04-12','13:16:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(283,1,8004,'2024-04-12','13:16:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(284,1,8000,'2024-04-12','13:17:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(285,1,8004,'2024-04-12','13:17:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(286,1,1,'2024-04-12','13:18:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(287,1,8000,'2024-04-12','13:18:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(288,1,8004,'2024-04-12','13:18:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(289,1,1,'2024-04-12','13:23:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(290,1,8000,'2024-04-12','13:23:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(291,1,8004,'2024-04-12','13:23:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(292,1,1,'2024-04-12','13:25:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(293,1,8000,'2024-04-12','13:25:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(294,1,8004,'2024-04-12','13:25:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(295,1,1,'2024-04-12','13:26:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(296,1,8000,'2024-04-12','13:26:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(297,1,8004,'2024-04-12','13:26:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(298,1,1,'2024-04-12','13:28:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(299,1,8000,'2024-04-12','13:28:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(300,1,8004,'2024-04-12','13:29:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(301,1,1,'2024-04-12','13:30:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(302,1,8000,'2024-04-12','13:30:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(303,1,8004,'2024-04-12','13:31:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(304,1,1,'2024-04-12','13:45:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(305,1,8000,'2024-04-12','13:45:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(306,1,1,'2024-04-12','13:52:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(307,1,8000,'2024-04-12','13:52:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(308,1,1,'2024-04-12','14:13:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(309,1,8000,'2024-04-12','14:13:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(310,1,1,'2024-04-12','14:13:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(311,1,8000,'2024-04-12','14:13:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(312,1,1,'2024-04-12','14:15:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(313,1,8000,'2024-04-12','14:15:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(314,1,1,'2024-04-12','14:18:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(315,1,8000,'2024-04-12','14:18:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(316,1,1,'2024-04-12','14:19:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(317,1,8000,'2024-04-12','14:19:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(318,1,1,'2024-04-12','14:27:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(319,1,8000,'2024-04-12','14:27:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(320,1,1,'2024-04-12','14:28:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(321,1,8000,'2024-04-12','14:28:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(322,1,1,'2024-04-12','14:28:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(323,1,8000,'2024-04-12','14:28:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(324,1,1,'2024-04-12','14:30:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(325,1,8000,'2024-04-12','14:30:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(326,1,1,'2024-04-12','14:32:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(327,1,8000,'2024-04-12','14:32:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(328,1,1,'2024-04-12','14:34:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(329,1,8000,'2024-04-12','14:34:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(330,1,1,'2024-04-12','14:35:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(331,1,8000,'2024-04-12','14:35:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(332,1,1,'2024-04-12','18:11:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(333,1,8000,'2024-04-12','18:11:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(334,1,1,'2024-04-12','18:17:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(335,1,8000,'2024-04-12','18:17:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(336,1,1,'2024-04-12','18:17:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(337,1,8000,'2024-04-12','18:17:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(338,1,8007,'2024-04-12','18:18:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(339,1,8008,'2024-04-12','18:18:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(340,1,8030,'2024-04-12','18:19:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(341,1,1000,'2024-04-12','18:21:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(342,1,1,'2024-04-12','18:29:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(343,1,8000,'2024-04-12','18:29:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(345,1,8000,'2024-04-12','18:30:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(346,1,1,'2024-04-12','18:30:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(347,1,8000,'2024-04-12','18:30:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(348,1,1,'2024-04-12','21:50:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(349,1,8000,'2024-04-12','21:50:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(350,1,1,'2024-04-12','21:50:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(351,1,8000,'2024-04-12','21:50:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(352,1,1,'2024-04-12','21:52:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(353,1,8000,'2024-04-12','21:52:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(354,1,1,'2024-04-12','21:53:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(355,1,8000,'2024-04-12','21:53:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(356,1,1,'2024-04-12','21:54:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(357,1,8000,'2024-04-12','21:54:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(358,1,1,'2024-04-12','22:29:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(359,1,8000,'2024-04-12','22:29:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(360,1,8001,'2024-04-12','22:29:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(361,1,8002,'2024-04-12','22:30:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(362,1,8002,'2024-04-12','22:30:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(363,1,8003,'2024-04-12','22:31:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(364,1,8004,'2024-04-12','22:32:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(365,1,8004,'2024-04-12','22:32:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(366,1,8007,'2024-04-12','22:33:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(367,1,8008,'2024-04-12','22:33:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(368,1,8030,'2024-04-12','22:34:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(369,1,1000,'2024-04-12','22:44:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(370,1,1,'2024-04-12','22:45:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(371,1,1000,'2024-04-12','22:45:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(372,1,1,'2024-04-12','22:51:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(373,1,8000,'2024-04-12','22:51:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(374,1,8002,'2024-04-12','22:51:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(375,1,8002,'2024-04-12','22:52:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(376,1,8002,'2024-04-12','22:52:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(377,1,1,'2024-04-12','22:54:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(378,1,8000,'2024-04-12','22:54:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(379,1,8002,'2024-04-12','22:54:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(380,1,1,'2024-04-15','20:39:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(381,1,8000,'2024-04-15','20:39:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(382,1,1,'2024-04-17','14:01:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(383,1,8000,'2024-04-17','14:01:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo Parcial'),(384,1,1,'2024-04-18','10:28:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(385,1,8000,'2024-04-18','10:28:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Cinevision parcial2'),(386,1,1,'2024-04-18','10:32:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(387,1,8000,'2024-04-18','10:32:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Cinevision parcial2'),(388,1,1,'2024-04-18','10:32:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(389,1,8000,'2024-04-18','10:32:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Cinevision parcial2'),(390,1,1,'2024-04-26','11:28:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(391,1,8000,'2024-04-26','11:28:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(392,1,1,'2024-04-26','11:31:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(393,1,8000,'2024-04-26','11:31:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(394,1,1,'2024-04-26','11:33:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(395,1,8000,'2024-04-26','11:33:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(396,1,1,'2024-04-26','11:39:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(397,1,8000,'2024-04-26','11:39:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(398,1,1,'2024-04-26','11:41:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(399,1,8000,'2024-04-26','11:41:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(400,1,1,'2024-04-26','11:42:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(401,1,1,'2024-04-26','11:42:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(402,1,8000,'2024-04-26','11:42:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(403,1,1,'2024-04-26','11:54:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(404,1,8000,'2024-04-26','11:54:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(405,1,1,'2024-04-26','11:56:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(406,1,8000,'2024-04-26','11:56:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(407,1,1,'2024-04-26','11:57:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(408,1,8000,'2024-04-26','11:57:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(409,1,1,'2024-04-26','11:58:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(410,1,8000,'2024-04-26','11:58:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(411,1,1,'2024-04-26','12:02:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(412,1,8000,'2024-04-26','12:02:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(413,1,1,'2024-04-26','12:11:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(414,1,8000,'2024-04-26','12:11:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(415,1,1,'2024-04-26','12:14:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(416,1,8000,'2024-04-26','12:14:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(417,1,1,'2024-04-26','12:17:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(418,1,8000,'2024-04-26','12:17:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(419,1,1,'2024-04-26','12:19:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(420,1,8000,'2024-04-26','12:19:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(421,1,1,'2024-04-26','12:21:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(422,1,8000,'2024-04-26','12:21:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(423,1,1,'2024-04-26','12:22:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(424,1,8000,'2024-04-26','12:22:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(425,1,1,'2024-04-26','12:25:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(426,1,8000,'2024-04-26','12:25:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(427,1,1,'2024-04-26','12:27:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(428,1,8000,'2024-04-26','12:27:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(429,1,1,'2024-04-26','12:28:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(430,1,8000,'2024-04-26','12:28:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(431,1,1,'2024-04-26','12:29:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(432,1,8000,'2024-04-26','12:29:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(433,1,1,'2024-04-26','12:35:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(434,1,8000,'2024-04-26','12:35:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(435,1,1,'2024-04-26','12:48:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(436,1,8000,'2024-04-26','12:48:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(437,1,1,'2024-04-26','12:52:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(438,1,8000,'2024-04-26','12:52:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(439,1,1,'2024-04-26','12:58:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(440,1,8000,'2024-04-26','12:58:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(441,1,1,'2024-04-26','13:00:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(442,1,8000,'2024-04-26','13:00:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(443,1,1,'2024-04-26','13:52:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(444,1,8000,'2024-04-26','13:52:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(445,1,1,'2024-04-26','17:11:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(446,1,8000,'2024-04-26','17:11:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(447,1,8005,'2024-04-26','17:12:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(448,1,1,'2024-04-26','17:13:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(449,1,8000,'2024-04-26','17:13:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(450,1,1,'2024-04-26','17:17:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(451,1,8000,'2024-04-26','17:17:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(452,1,8005,'2024-04-26','17:18:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(453,1,1,'2024-04-26','17:18:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(454,1,8000,'2024-04-26','17:18:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(455,1,1,'2024-04-26','17:24:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(456,1,8000,'2024-04-26','17:24:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(457,1,8005,'2024-04-26','17:25:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(458,1,1,'2024-04-26','17:27:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(459,1,8000,'2024-04-26','17:28:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(460,1,8005,'2024-04-26','17:28:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(461,1,1,'2024-04-26','17:30:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(462,1,8000,'2024-04-26','17:30:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(463,1,1,'2024-04-26','17:33:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(464,1,8000,'2024-04-26','17:33:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(465,1,1,'2024-04-26','17:34:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(466,1,8000,'2024-04-26','17:34:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(467,1,8005,'2024-04-26','17:35:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(468,1,1,'2024-04-26','17:36:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(469,1,8000,'2024-04-26','17:36:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(470,1,8005,'2024-04-26','17:36:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha modificado un registro'),(471,1,8005,'2024-04-26','17:36:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(472,1,1,'2024-04-26','18:06:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(473,1,8000,'2024-04-26','18:06:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(474,1,1,'2024-04-26','18:12:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(475,1,8000,'2024-04-26','18:12:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(476,1,1,'2024-04-26','18:22:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(477,1,8000,'2024-04-26','18:22:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(478,1,8002,'2024-04-26','18:22:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(479,1,1,'2024-04-26','18:23:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(480,1,8000,'2024-04-26','18:23:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(481,1,8002,'2024-04-26','18:24:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(482,1,1,'2024-04-30','09:28:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(483,1,8000,'2024-04-30','09:28:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(484,1,8000,'2024-04-30','09:29:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(485,1,8002,'2024-04-30','09:54:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(486,1,8000,'2024-04-30','10:06:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(487,1,1,'2024-04-30','21:22:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(488,1,8000,'2024-04-30','21:22:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(489,1,1,'2024-04-30','21:24:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(490,1,8000,'2024-04-30','21:24:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(491,1,1,'2024-04-30','21:30:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(492,1,8000,'2024-04-30','21:30:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(493,1,1,'2024-04-30','21:33:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(494,1,8000,'2024-04-30','21:33:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(495,1,1,'2024-04-30','21:34:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(496,1,8000,'2024-04-30','21:34:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(497,1,1,'2024-04-30','21:36:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(498,1,8000,'2024-04-30','21:36:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(499,1,1,'2024-04-30','22:01:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(500,1,8000,'2024-04-30','22:01:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(501,1,1,'2024-05-02','16:09:09','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(502,1,8000,'2024-05-02','16:09:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(503,1,1,'2024-05-02','16:11:53','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(504,1,8000,'2024-05-02','16:11:54','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(505,1,1,'2024-05-02','16:15:35','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(506,1,8000,'2024-05-02','16:15:37','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(507,1,1,'2024-05-02','16:22:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(508,1,8000,'2024-05-02','16:22:11','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(509,1,1,'2024-05-02','16:38:40','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(510,1,8000,'2024-05-02','16:38:42','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(511,1,1,'2024-05-02','16:41:18','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(512,1,8000,'2024-05-02','16:41:19','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(513,1,1,'2024-05-02','16:46:51','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(514,1,8000,'2024-05-02','16:46:53','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(515,1,1,'2024-05-02','17:00:23','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(516,1,8000,'2024-05-02','17:00:24','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(517,1,1,'2024-05-02','18:37:16','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(518,1,8000,'2024-05-02','18:37:17','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(519,1,1,'2024-05-02','18:38:07','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(520,1,8000,'2024-05-02','18:38:08','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(521,1,1,'2024-05-02','21:13:45','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(522,1,8000,'2024-05-02','21:13:46','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(523,1,1,'2024-05-02','21:17:38','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(524,1,8000,'2024-05-02','21:17:39','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(525,1,1,'2024-05-02','21:20:20','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(526,1,8000,'2024-05-02','21:20:22','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(527,1,1,'2024-05-02','21:28:34','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(528,1,8000,'2024-05-02','21:28:36','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(529,1,1,'2024-05-02','21:30:53','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(530,1,8000,'2024-05-02','21:30:55','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(531,1,1,'2024-05-02','21:32:57','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(532,1,8000,'2024-05-02','21:32:59','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(533,1,1,'2024-05-02','21:41:24','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(534,1,8000,'2024-05-02','21:41:25','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(535,1,1,'2024-05-02','21:44:01','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(536,1,8000,'2024-05-02','21:44:03','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(537,1,1,'2024-05-02','21:50:39','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(538,1,8000,'2024-05-02','21:50:41','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(539,1,1,'2024-05-02','21:52:43','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(540,1,8000,'2024-05-02','21:52:45','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(541,1,1,'2024-05-02','21:54:03','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(542,1,8000,'2024-05-02','21:54:04','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(543,1,1,'2024-05-02','22:02:05','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(544,1,8000,'2024-05-02','22:02:06','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(545,1,1,'2024-05-02','22:05:09','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(546,1,8000,'2024-05-02','22:05:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(547,1,1,'2024-05-02','22:05:54','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(548,1,8000,'2024-05-02','22:05:58','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(549,1,1,'2024-05-02','22:11:07','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(550,1,8000,'2024-05-02','22:11:08','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(551,1,1,'2024-05-02','22:13:39','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(552,1,8000,'2024-05-02','22:13:41','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(553,1,1,'2024-05-02','22:14:40','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(554,1,8000,'2024-05-02','22:14:41','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(555,1,1,'2024-05-02','22:16:02','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(556,1,8000,'2024-05-02','22:16:03','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(557,1,1,'2024-05-02','22:18:32','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(558,1,8000,'2024-05-02','22:18:33','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(559,1,1,'2024-05-02','22:20:13','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(560,1,8000,'2024-05-02','22:20:14','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(561,1,1,'2024-05-02','22:22:51','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(562,1,8000,'2024-05-02','22:22:52','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(563,1,1,'2024-05-02','22:25:21','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(564,1,8000,'2024-05-02','22:25:22','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(565,1,1,'2024-05-02','22:29:40','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(566,1,8000,'2024-05-02','22:29:41','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(567,1,1,'2024-05-02','22:31:20','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(568,1,8000,'2024-05-02','22:31:21','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(569,1,1,'2024-05-02','22:32:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(570,1,8000,'2024-05-02','22:32:12','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(571,1,1,'2024-05-02','22:33:29','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(572,1,8000,'2024-05-02','22:33:30','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(573,1,1,'2024-05-02','22:39:15','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(574,1,8000,'2024-05-02','22:39:16','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(575,1,1,'2024-05-02','22:41:20','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(576,1,8000,'2024-05-02','22:41:21','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(577,1,1,'2024-05-02','22:46:19','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(578,1,8000,'2024-05-02','22:46:20','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(579,1,1,'2024-05-02','22:48:33','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(580,1,8000,'2024-05-02','22:48:34','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(581,1,1,'2024-05-02','22:49:36','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(582,1,8000,'2024-05-02','22:49:37','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(583,1,1,'2024-05-02','22:51:11','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(584,1,8000,'2024-05-02','22:51:12','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(585,1,1,'2024-05-02','22:52:35','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(586,1,8000,'2024-05-02','22:52:36','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(587,1,1,'2024-05-02','22:58:49','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(588,1,8000,'2024-05-02','22:58:51','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(589,1,1,'2024-05-02','22:59:54','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(590,1,8000,'2024-05-02','22:59:55','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(591,1,1,'2024-05-02','23:02:35','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(592,1,8000,'2024-05-02','23:02:36','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(593,1,1,'2024-05-02','23:04:26','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(594,1,8000,'2024-05-02','23:04:27','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(595,1,1,'2024-05-02','23:04:56','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(596,1,8000,'2024-05-02','23:04:57','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(597,1,1,'2024-05-02','23:06:14','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(598,1,8000,'2024-05-02','23:06:16','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(599,1,1,'2024-05-02','23:07:58','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(600,1,8000,'2024-05-02','23:07:58','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(601,1,1,'2024-05-03','13:14:20','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(602,1,8000,'2024-05-03','13:14:22','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(603,1,1,'2024-05-03','13:15:22','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(604,1,8000,'2024-05-03','13:15:23','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(605,1,1,'2024-05-03','13:19:22','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(606,1,1000,'2024-05-03','13:19:23','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Seguridad'),(607,1,1,'2024-05-03','13:19:33','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(608,1,8000,'2024-05-03','13:19:35','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(609,1,1,'2024-05-03','13:23:48','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(610,1,8000,'2024-05-03','13:23:49','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(611,1,1,'2024-05-03','13:26:09','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(612,1,8000,'2024-05-03','13:26:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(613,1,1,'2024-05-03','13:27:46','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(614,1,8000,'2024-05-03','13:27:47','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(615,1,1,'2024-05-03','13:29:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(616,1,8000,'2024-05-03','13:29:11','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(617,1,1,'2024-05-03','13:30:04','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(618,1,8000,'2024-05-03','13:30:04','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(619,1,1,'2024-05-03','13:30:33','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(620,1,8000,'2024-05-03','13:30:34','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(621,1,1,'2024-05-03','13:31:59','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(622,1,8000,'2024-05-03','13:32:01','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(623,1,1,'2024-05-03','13:37:37','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(624,1,8000,'2024-05-03','13:37:38','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(625,1,1,'2024-05-03','13:37:54','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(626,1,8000,'2024-05-03','13:37:55','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(627,1,1,'2024-05-03','13:38:14','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(628,1,8000,'2024-05-03','13:38:15','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(629,1,1,'2024-05-03','17:19:05','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(630,1,8000,'2024-05-03','17:19:06','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(631,1,1,'2024-05-03','17:26:08','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(632,1,8000,'2024-05-03','17:26:10','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(633,1,1,'2024-05-03','17:27:43','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(634,1,8000,'2024-05-03','17:27:45','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(635,1,8001,'2024-05-03','17:28:41','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha eliminado un registro'),(636,1,8001,'2024-05-03','17:28:47','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha eliminado un registro'),(637,1,8001,'2024-05-03','17:28:55','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha eliminado un registro'),(638,1,8001,'2024-05-03','17:29:17','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(639,1,8001,'2024-05-03','17:29:45','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(640,1,8001,'2024-05-03','17:30:11','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(641,1,8001,'2024-05-03','17:30:42','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(642,1,8002,'2024-05-03','17:31:02','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(643,1,8002,'2024-05-03','17:31:14','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(644,1,8005,'2024-05-03','17:32:04','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(645,1,8005,'2024-05-03','17:32:34','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha guardado un registro'),(646,1,8005,'2024-05-03','17:32:49','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Se ha modificado un registro'),(647,1,1,'2024-05-03','17:39:50','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(648,1,8000,'2024-05-03','17:39:51','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(649,1,1,'2024-05-03','17:43:19','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(650,1,8000,'2024-05-03','17:43:20','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(651,1,1,'2024-05-03','18:16:49','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(652,1,8000,'2024-05-03','18:16:51','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(653,1,1,'2024-05-03','18:18:50','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(654,1,8000,'2024-05-03','18:18:51','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(655,1,1,'2024-05-07','10:03:31','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Login'),(656,1,8000,'2024-05-07','10:03:32','LAPTOP-R6RT5UAG','2606:4700:110:8ab0:59ad:6136:ac91:c087','Ingreso Prototipo'),(657,1,1,'2024-05-09','10:12:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(658,1,8000,'2024-05-09','10:13:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(659,1,1,'2024-05-09','18:39:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(660,1,8000,'2024-05-09','18:39:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(661,1,1,'2024-05-09','18:43:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(662,1,8000,'2024-05-09','18:43:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(663,1,1,'2024-05-09','18:48:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(664,1,8000,'2024-05-09','18:48:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(665,1,1,'2024-05-09','18:50:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(666,1,8000,'2024-05-09','18:50:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(667,1,1,'2024-05-09','18:58:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(668,1,8000,'2024-05-09','18:58:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(669,1,1,'2024-05-09','19:03:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(670,1,8000,'2024-05-09','19:03:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(671,1,1,'2024-05-09','19:05:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(672,1,8000,'2024-05-09','19:09:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(673,1,1,'2024-05-10','18:11:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(674,1,8000,'2024-05-10','18:11:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(675,1,1,'2024-05-10','18:24:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(676,1,8000,'2024-05-10','18:24:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(677,1,1,'2024-05-10','18:26:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(678,1,8000,'2024-05-10','18:26:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(679,1,1,'2024-05-10','18:35:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(680,1,8000,'2024-05-10','18:35:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(681,1,1,'2024-05-10','18:45:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(682,1,8000,'2024-05-10','18:45:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(683,1,1,'2024-05-10','18:48:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(684,1,8000,'2024-05-10','18:48:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(685,1,1,'2024-05-11','13:19:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(686,1,8000,'2024-05-11','13:19:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(687,1,1,'2024-05-11','14:17:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(688,1,8000,'2024-05-11','14:17:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(689,1,1,'2024-05-11','14:18:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(690,1,8000,'2024-05-11','14:18:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(691,1,1,'2024-05-11','14:22:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(692,1,1,'2024-05-11','14:22:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(693,1,8000,'2024-05-11','14:22:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(694,1,1,'2024-05-11','14:28:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(695,1,8000,'2024-05-11','14:28:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(696,1,1,'2024-05-11','14:29:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(697,1,8000,'2024-05-11','14:29:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(698,1,1,'2024-05-11','14:30:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(699,1,8000,'2024-05-11','14:30:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(700,1,1,'2024-05-11','14:31:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(701,1,8000,'2024-05-11','14:31:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(702,1,1,'2024-05-11','14:32:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(703,1,8000,'2024-05-11','14:32:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(704,1,8031,'2024-05-11','14:32:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(705,1,1000,'2024-05-11','14:35:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(706,1,1,'2024-05-11','14:35:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(707,1,8000,'2024-05-11','14:35:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(708,1,8009,'2024-05-11','14:36:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(709,1,8009,'2024-05-11','14:36:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(710,1,1,'2024-05-11','14:39:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(711,1,8000,'2024-05-11','14:39:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(712,1,1,'2024-05-11','14:43:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(713,1,8000,'2024-05-11','14:43:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(714,1,1,'2024-05-11','14:46:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(715,1,8000,'2024-05-11','14:46:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(716,1,8031,'2024-05-11','14:58:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(717,1,8009,'2024-05-11','15:01:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(718,1,1000,'2024-05-11','15:02:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(719,1,1,'2024-05-15','08:30:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(720,1,8000,'2024-05-15','08:30:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(721,1,1,'2024-05-15','09:07:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(722,1,8000,'2024-05-15','09:07:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(723,1,1,'2024-05-15','09:10:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(724,1,8000,'2024-05-15','09:10:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(725,1,1,'2024-05-15','09:26:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(726,1,8000,'2024-05-15','09:26:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(727,1,1,'2024-05-15','09:27:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(728,1,8000,'2024-05-15','09:27:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(729,1,1,'2024-05-15','09:28:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(730,1,8000,'2024-05-15','09:29:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(731,1,1,'2024-05-15','09:30:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(732,1,8000,'2024-05-15','09:30:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(733,1,1,'2024-05-15','09:38:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(734,1,8000,'2024-05-15','09:38:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(735,1,1,'2024-05-15','09:40:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(736,1,8000,'2024-05-15','09:40:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(737,1,1,'2024-05-15','09:43:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(738,1,8000,'2024-05-15','09:43:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(739,1,8000,'2024-05-15','09:49:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(740,1,1,'2024-05-15','09:52:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Login'),(741,1,8000,'2024-05-15','09:52:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%12','Ingreso Prototipo'),(742,1,1,'2024-05-16','08:42:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(743,1,8000,'2024-05-16','09:43:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(744,1,1,'2024-05-16','16:26:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(745,1,8000,'2024-05-16','16:26:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(746,1,1,'2024-05-16','16:30:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(747,1,8000,'2024-05-16','16:30:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(748,1,1,'2024-05-16','16:31:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(749,1,8000,'2024-05-16','16:31:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(750,1,1,'2024-05-16','16:48:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(751,1,8000,'2024-05-16','16:48:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(752,1,1,'2024-05-16','16:55:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(753,1,8000,'2024-05-16','16:55:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(754,1,1,'2024-05-16','16:57:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(755,1,8000,'2024-05-16','16:57:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(756,1,1,'2024-05-16','16:59:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(757,1,8000,'2024-05-16','16:59:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(758,1,1,'2024-05-16','17:02:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(759,1,1,'2024-05-16','17:02:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(760,1,8000,'2024-05-16','17:02:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(761,1,1,'2024-05-16','17:12:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(762,1,8000,'2024-05-16','17:12:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(763,1,1,'2024-05-16','17:15:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(764,1,8000,'2024-05-16','17:15:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(765,1,1,'2024-05-16','17:40:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(766,1,8000,'2024-05-16','17:40:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(767,1,1,'2024-05-16','17:44:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(768,1,8000,'2024-05-16','17:44:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(769,1,1,'2024-05-16','17:49:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(770,1,8000,'2024-05-16','17:49:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(771,1,1,'2024-05-16','17:52:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(772,1,8000,'2024-05-16','17:52:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(773,1,1,'2024-05-16','17:56:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(774,1,8000,'2024-05-16','17:56:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(775,1,1,'2024-05-16','17:57:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(776,1,8000,'2024-05-16','17:57:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(777,1,1,'2024-05-16','17:59:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(778,1,1000,'2024-05-16','17:59:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(779,1,1,'2024-05-16','18:00:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(780,1,8000,'2024-05-16','18:00:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(781,1,1,'2024-05-16','18:00:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(782,1,8000,'2024-05-16','18:00:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(783,1,1,'2024-05-16','18:03:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(784,1,8000,'2024-05-16','18:03:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(785,1,1,'2024-05-16','18:03:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(786,1,8000,'2024-05-16','18:03:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(787,1,1,'2024-05-16','18:06:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(788,1,8000,'2024-05-16','18:06:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(789,1,1,'2024-05-16','18:07:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(790,1,8000,'2024-05-16','18:07:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(791,1,1,'2024-05-16','18:11:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(792,1,8000,'2024-05-16','18:11:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(793,1,1,'2024-05-16','18:13:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(794,1,8000,'2024-05-16','18:13:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(795,1,1,'2024-05-16','18:46:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(796,1,8000,'2024-05-16','18:46:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(797,1,1,'2024-05-16','18:48:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(798,1,8000,'2024-05-16','18:48:24','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(799,1,1,'2024-05-16','18:49:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(800,1,8000,'2024-05-16','18:49:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(801,1,1,'2024-05-16','18:51:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(802,1,8000,'2024-05-16','18:51:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(803,1,1,'2024-05-16','18:52:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(804,1,8000,'2024-05-16','18:52:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(805,1,1,'2024-05-16','19:01:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(806,1,8000,'2024-05-16','19:01:04','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(807,1,1,'2024-05-16','19:04:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(808,1,8000,'2024-05-16','19:04:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(809,1,1,'2024-05-16','19:12:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(810,1,1,'2024-05-16','19:15:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(811,1,8000,'2024-05-16','19:15:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(812,1,1,'2024-05-16','19:18:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(813,1,8000,'2024-05-16','19:18:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(814,1,1,'2024-05-16','19:19:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(815,1,8000,'2024-05-16','19:19:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(816,1,1,'2024-05-16','19:20:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(817,1,8000,'2024-05-16','19:20:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(818,1,1,'2024-05-16','19:39:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(819,1,8000,'2024-05-16','19:39:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(820,1,1,'2024-05-16','19:42:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(821,1,8000,'2024-05-16','19:42:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(822,1,1,'2024-05-16','19:45:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(823,1,8000,'2024-05-16','19:45:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(824,1,1,'2024-05-16','19:46:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(825,1,8000,'2024-05-16','19:46:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(826,1,1,'2024-05-16','19:47:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(827,1,8000,'2024-05-16','19:47:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(828,1,1,'2024-05-16','19:53:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(829,1,8000,'2024-05-16','19:53:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(830,1,1,'2024-05-16','19:56:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(831,1,8000,'2024-05-16','19:56:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(832,1,1,'2024-05-16','19:57:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(833,1,8000,'2024-05-16','19:57:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(834,1,1,'2024-05-18','11:41:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(835,1,8000,'2024-05-18','11:41:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(836,1,1,'2024-05-18','14:43:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(837,1,8000,'2024-05-18','14:43:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(838,1,1,'2024-05-18','14:44:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(839,1,8000,'2024-05-18','14:44:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(840,1,8010,'2024-05-18','14:45:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ingresó una órden de compra'),(841,1,1,'2024-05-18','14:51:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(842,1,8000,'2024-05-18','14:51:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(843,1,8020,'2024-05-18','14:54:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(844,1,1,'2024-05-18','14:56:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(845,1,8000,'2024-05-18','14:56:51','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(846,1,8031,'2024-05-18','14:56:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(847,1,1,'2024-05-18','15:01:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(848,1,8000,'2024-05-18','15:01:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(849,1,8031,'2024-05-18','15:01:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(850,1,1,'2024-05-18','15:02:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(851,1,8000,'2024-05-18','15:02:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(852,1,8031,'2024-05-18','15:02:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(853,1,1,'2024-05-18','15:09:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(854,1,8000,'2024-05-18','15:09:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(855,1,1,'2024-05-18','15:20:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(856,1,8000,'2024-05-18','15:20:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(857,1,8020,'2024-05-18','15:28:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(858,1,8031,'2024-05-18','15:31:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(859,1,1000,'2024-05-18','15:33:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(860,1,1,'2024-05-21','09:28:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(861,1,8000,'2024-05-21','09:28:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(862,1,1,'2024-05-21','09:49:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(863,1,8000,'2024-05-21','09:49:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(864,1,1,'2024-05-21','09:57:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(865,1,8000,'2024-05-21','09:57:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(866,1,1,'2024-05-22','08:13:05','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(867,1,8000,'2024-05-22','08:13:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(868,1,1,'2024-05-22','08:15:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(869,1,8000,'2024-05-22','08:15:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(870,1,1,'2024-05-22','08:31:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(871,1,8000,'2024-05-22','08:31:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(872,1,1,'2024-05-22','08:32:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(873,1,8000,'2024-05-22','08:32:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(874,1,1,'2024-05-22','08:42:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(875,1,8000,'2024-05-22','08:42:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(876,1,1,'2024-05-22','08:51:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(877,1,8000,'2024-05-22','08:51:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(878,1,1,'2024-05-22','08:54:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(879,1,8000,'2024-05-22','08:54:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(880,1,1,'2024-05-22','16:22:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(881,1,8000,'2024-05-22','16:22:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(882,1,8031,'2024-05-22','16:22:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(883,1,8020,'2024-05-22','16:25:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(884,1,1,'2024-05-22','16:26:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(885,1,8000,'2024-05-22','16:26:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(886,1,8031,'2024-05-22','16:27:53','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(887,1,8020,'2024-05-22','16:28:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(888,1,1,'2024-05-22','16:33:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(889,1,8000,'2024-05-22','16:33:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(890,1,1,'2024-05-22','16:40:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(891,1,8000,'2024-05-22','16:40:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(892,1,1,'2024-05-22','16:48:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(893,1,8000,'2024-05-22','16:48:40','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(894,1,8020,'2024-05-22','16:48:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(895,1,1,'2024-05-22','16:51:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(896,1,8000,'2024-05-22','16:51:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(897,1,1,'2024-05-22','16:52:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(898,1,8000,'2024-05-22','16:52:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(899,1,1,'2024-05-22','16:54:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(900,1,8000,'2024-05-22','16:54:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(901,1,1,'2024-05-22','16:57:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(902,1,8000,'2024-05-22','16:57:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(903,1,1,'2024-05-22','16:59:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(904,1,8000,'2024-05-22','17:00:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(905,1,1,'2024-05-22','17:03:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(906,1,8000,'2024-05-22','17:03:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(907,1,1,'2024-05-22','17:07:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(908,1,8000,'2024-05-22','17:07:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(909,1,1,'2024-05-22','17:26:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(910,1,8000,'2024-05-22','17:26:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(911,1,1,'2024-05-22','17:37:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(912,1,8000,'2024-05-22','17:37:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(913,1,1,'2024-05-22','17:39:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(914,1,8000,'2024-05-22','17:39:15','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(915,1,1,'2024-05-22','17:42:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(916,1,8000,'2024-05-22','17:42:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(917,1,1,'2024-05-22','17:43:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(918,1,8000,'2024-05-22','17:43:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(919,1,1,'2024-05-22','17:44:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(920,1,8000,'2024-05-22','17:44:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(921,1,1,'2024-05-22','17:45:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(922,1,8000,'2024-05-22','17:45:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(923,1,1,'2024-05-22','17:52:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(924,1,8000,'2024-05-22','17:52:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(925,1,1,'2024-05-22','17:56:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(926,1,8000,'2024-05-22','17:56:22','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(927,1,1,'2024-05-22','17:58:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(928,1,8000,'2024-05-22','17:58:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(929,1,1,'2024-05-22','18:05:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(930,1,8000,'2024-05-22','18:05:35','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(931,1,1,'2024-05-22','18:05:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(932,1,8000,'2024-05-22','18:05:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(933,1,1,'2024-05-22','18:08:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(934,1,8000,'2024-05-22','18:08:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(935,1,1,'2024-05-22','18:09:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(936,1,8000,'2024-05-22','18:09:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(937,1,1,'2024-05-22','18:11:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(938,1,8000,'2024-05-22','18:11:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(939,1,1,'2024-05-22','18:12:25','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(940,1,8000,'2024-05-22','18:12:31','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(941,1,1,'2024-05-22','18:17:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(942,1,8000,'2024-05-22','18:17:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(943,1,1,'2024-05-22','18:19:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(944,1,8000,'2024-05-22','18:19:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(945,1,1,'2024-05-22','18:26:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(946,1,8000,'2024-05-22','18:26:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(947,1,1,'2024-05-22','20:05:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(948,1,8000,'2024-05-22','20:05:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(949,1,1,'2024-05-22','20:12:52','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(950,1,8000,'2024-05-22','20:12:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(951,1,1,'2024-05-22','20:15:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(952,1,8000,'2024-05-22','20:15:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(953,1,1,'2024-05-22','20:17:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(954,1,8000,'2024-05-22','20:17:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(955,1,1,'2024-05-22','20:18:36','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(956,1,8000,'2024-05-22','20:18:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(957,1,1,'2024-05-22','20:20:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(958,1,8000,'2024-05-22','20:20:08','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(959,1,1,'2024-05-22','20:22:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(960,1,8000,'2024-05-22','20:22:27','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(961,1,1,'2024-05-22','20:32:16','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(962,1,8000,'2024-05-22','20:32:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(963,1,1000,'2024-05-22','20:32:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(964,1,1,'2024-05-22','20:49:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(965,1,8000,'2024-05-22','20:49:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(966,1,1000,'2024-05-22','20:49:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(967,1,1,'2024-05-22','21:09:26','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(968,1,8000,'2024-05-22','21:09:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(969,1,1,'2024-05-22','21:10:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(970,1,8000,'2024-05-22','21:10:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(971,1,1,'2024-05-22','21:12:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(972,1,8000,'2024-05-22','21:12:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(973,1,1,'2024-05-22','21:14:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(974,1,8000,'2024-05-22','21:14:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(975,1,1,'2024-05-22','21:16:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(976,1,8000,'2024-05-22','21:16:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(977,1,1,'2024-05-22','21:17:58','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(978,1,8000,'2024-05-22','21:17:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(979,1,1,'2024-05-22','21:26:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(980,1,8000,'2024-05-22','21:26:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(981,1,1,'2024-05-22','21:27:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(982,1,8000,'2024-05-22','21:27:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(983,1,1,'2024-05-22','21:29:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(984,1,8000,'2024-05-22','21:29:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(985,1,1,'2024-05-22','22:48:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(986,1,8000,'2024-05-22','22:48:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(987,1,1,'2024-05-22','22:51:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(988,1,8000,'2024-05-22','22:51:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(989,1,1,'2024-05-23','08:00:01','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(990,1,8000,'2024-05-23','08:00:03','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(991,1,1,'2024-05-23','08:02:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(992,1,8000,'2024-05-23','08:02:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(993,1,8020,'2024-05-23','08:02:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(994,1,1,'2024-05-23','08:03:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(995,1,8000,'2024-05-23','08:03:39','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(996,1,8020,'2024-05-23','08:04:00','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(997,1,1,'2024-05-23','08:09:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(998,1,8000,'2024-05-23','08:09:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(999,1,1,'2024-05-23','08:40:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1000,1,8000,'2024-05-23','08:40:23','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1001,1,1,'2024-05-23','08:41:45','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1002,1,8000,'2024-05-23','08:41:47','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1003,1,1,'2024-05-23','08:51:17','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1004,1,8000,'2024-05-23','08:51:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1005,1,8005,'2024-05-23','08:53:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(1006,1,8005,'2024-05-23','08:53:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(1007,1,8005,'2024-05-23','08:54:11','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(1008,1,8001,'2024-05-23','08:57:32','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(1009,1,8003,'2024-05-23','08:58:12','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(1010,1,1,'2024-05-23','08:58:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1011,1,8000,'2024-05-23','08:58:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1012,1,8010,'2024-05-23','09:03:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ingresó una órden de compra'),(1013,1,8010,'2024-05-23','09:04:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se modificó una órden de compra'),(1014,1,8011,'2024-05-23','09:07:57','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ingresó una compra'),(1015,1,8011,'2024-05-23','09:10:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se modificó una compra'),(1016,1,8012,'2024-05-23','09:13:13','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ingresó una factura'),(1017,1,8013,'2024-05-23','09:14:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Operaciones Proveedores'),(1018,1,1,'2024-05-23','09:27:33','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1019,1,8000,'2024-05-23','09:27:34','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1020,1,1,'2024-05-23','09:28:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1021,1,8000,'2024-05-23','09:28:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1022,1,1,'2024-05-23','09:31:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1023,1,8000,'2024-05-23','09:31:21','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1024,1,1,'2024-05-23','09:32:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1025,1,8000,'2024-05-23','09:32:19','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1026,1,8020,'2024-05-23','09:49:09','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(1027,1,8031,'2024-05-23','09:54:07','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(1028,1,8020,'2024-05-23','09:55:41','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(1029,1,8020,'2024-05-23','09:57:14','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(1030,1,8031,'2024-05-23','09:58:18','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(1031,1,1000,'2024-05-23','09:59:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(1032,1,1,'2024-05-23','11:03:46','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1033,1,8000,'2024-05-23','11:03:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1034,1,8013,'2024-05-23','11:04:06','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Operaciones Proveedores'),(1035,1,1,'2024-05-23','11:22:48','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1036,1,8000,'2024-05-23','11:22:54','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1037,1,1,'2024-05-23','11:39:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1038,1,8000,'2024-05-23','11:39:44','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1039,1,1,'2024-05-23','13:21:37','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1040,1,8000,'2024-05-23','13:21:38','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1041,1,1,'2024-05-23','14:13:42','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1042,1,8000,'2024-05-23','14:13:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1043,1,1,'2024-05-23','14:17:28','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1044,1,8000,'2024-05-23','14:17:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1045,1,1,'2024-05-23','17:30:29','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1046,1,8000,'2024-05-23','17:30:30','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1047,1,8004,'2024-05-23','17:32:02','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha eliminado un registro'),(1048,1,8004,'2024-05-23','17:39:59','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha guardado un registro'),(1049,1,8004,'2024-05-23','18:08:56','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Se ha eliminado un registro'),(1050,1,8020,'2024-05-23','18:51:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de autorizacion ordenes de compra'),(1052,1,8031,'2024-05-23','19:44:43','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Pro. Bitacora de movimiento de bancos'),(1053,1,1000,'2024-05-23','20:12:20','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad'),(1054,1,1,'2024-05-23','20:12:49','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Login'),(1055,1,8000,'2024-05-23','20:12:50','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1056,1,8000,'2024-05-23','20:17:10','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Prototipo'),(1057,1,1000,'2024-05-23','20:26:55','LAPTOP-R6RT5UAG','fe80::b0e1:4dc3:fcc8:4576%10','Ingreso Seguridad');
/*!40000 ALTER TABLE `tbl_bitacoradeeventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_bodegas`
--

DROP TABLE IF EXISTS `tbl_bodegas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_bodegas` (
  `id_bodega` int NOT NULL AUTO_INCREMENT,
  `nombre_bodega` varchar(45) NOT NULL,
  `ubicacion_bodega` varchar(45) NOT NULL,
  `capacidad_bodega` int NOT NULL,
  PRIMARY KEY (`id_bodega`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_bodegas`
--

LOCK TABLES `tbl_bodegas` WRITE;
/*!40000 ALTER TABLE `tbl_bodegas` DISABLE KEYS */;
INSERT INTO `tbl_bodegas` VALUES (1,'BytechBodega','Mixco',20);
/*!40000 ALTER TABLE `tbl_bodegas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_clientes`
--

DROP TABLE IF EXISTS `tbl_clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_clientes` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `nombre_cl` varchar(50) NOT NULL,
  `apellido_cl` varchar(50) NOT NULL,
  `direccion_cl` varchar(100) NOT NULL,
  `correo_cl` varchar(100) NOT NULL,
  `telefono_cl` varchar(45) NOT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=365 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_clientes`
--

LOCK TABLES `tbl_clientes` WRITE;
/*!40000 ALTER TABLE `tbl_clientes` DISABLE KEYS */;
INSERT INTO `tbl_clientes` VALUES (1,'aalonos','alex','a','a','a'),(2,'Lucas','hernandez','zon2','l@mail.com','123412'),(3,'David','Carrillo','Mixco','dav@mail.com','187652'),(4,'sas','das','das','das','sad'),(13,'Jose','Martinez','zona4','josm@mail.com','42142341'),(14,'Lucas','Hernandez','zona4','lc','412421'),(15,'David','a','a','a','a'),(28,'barrios','balines','b','b','b'),(35,'David','Carrillo','zona2','carri@mail.com','512521'),(100,'David','Carrillo','mixco','car@mail.','123123'),(101,'Andrea','Cecilia','su casita','coradoa@mail.com','5682135'),(321,'Jose','Martinez','zona4','jos@mail.com','12412'),(322,'Jose','Escobar','zona4','esc@mail.com','421421'),(330,'Jose Maria','ordoñez','zona2','jos@mail.com','1124512'),(331,'Saul','Martinez','zona4','su@mail.com','8628632'),(332,'fafa','fafa','1231','faf@mail.com','12312'),(333,'Jose ','Martinez','zona2','js@mail.com','21412'),(334,'jose','antonio','zona2','js@mail.com','12412'),(335,'Jose','Martinez','zona3','josmar@mail.com','13231241'),(336,'Lucas','hernandez','zona4 de mixco','lc@mail.com','87659340'),(337,'Lucia','Ordoñez','zona 4 de la capital','luc@mail.com','12412412'),(338,'David','Carrillo','zona 2 capital','dc@mail.com','42875492'),(339,'Luis','Martinez','Zona5','luis@mai.com','872124'),(340,'Marta','Almiron','zona4 Guatemala','mar@mail.com','2849123'),(341,'Lucy','Hernandez','mixco zona 2','luc@mail.com','123123124'),(342,'lupe','corado','zona4 de mixco','lup@mail.com','5721846522'),(343,'Manuel Andres','Cercado','zona2 de mixco','manu@mail.com','76459823'),(344,'Joao','Martinez','Zona 3 de Guatemala','jo@mail.com','15212512'),(357,'Luna','Martinez','zona4 jutiapa','lun@mail.mail','1412421'),(358,'Pablo','Morales','villa nueva','Pabluski@mail.com','24128745'),(359,'Pablo','Morales','villa nueva','Pabluski@mail.com','24128745'),(360,'Sol','Martinez','zona4 de guatemala','sol@mail.com','17264126'),(361,'Antonio','Alvaraddo','zona4 Mixco','anto@mail.com','1512512'),(362,'Cliente','Examen','zona2 capital','cl@mail.com','864231'),(363,'cliente','examen','zona2 capital','cliente@mail.com','75436210'),(364,'Enry','Castillo','zona2 izabal','enr@mail.com','65423142');
/*!40000 ALTER TABLE `tbl_clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_compras`
--

DROP TABLE IF EXISTS `tbl_compras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_compras` (
  `id_EncComp` int NOT NULL AUTO_INCREMENT,
  `fechaSolicitid_EncComp` date NOT NULL,
  `fechaEntrega_OrdComp` date NOT NULL,
  `deptoSolicitante_EncComp` varchar(45) NOT NULL,
  `subTotal_EncComp` decimal(10,2) DEFAULT NULL,
  `iva_EncComp` decimal(10,2) DEFAULT NULL,
  `totalOrden_EncComp` decimal(10,2) DEFAULT NULL,
  `notas_EncComp` varchar(45) NOT NULL,
  `tbl_proveedor_id_prov` int NOT NULL,
  `recibidoIgualSolicitado_EncComp` int NOT NULL,
  `fechaVencimientoPago_EncComp` date NOT NULL,
  `id_OrdComp` int NOT NULL,
  PRIMARY KEY (`id_EncComp`),
  KEY `fk_tbl_Encabezado_Compras_tbl_proveedor1_idx` (`tbl_proveedor_id_prov`),
  KEY `fk_OrdenCompra` (`id_OrdComp`),
  CONSTRAINT `fk_OrdenCompra` FOREIGN KEY (`id_OrdComp`) REFERENCES `tbl_ordenescompra` (`id_OrdComp`),
  CONSTRAINT `fk_tbl_Encabezado_Compras_tbl_proveedor1` FOREIGN KEY (`tbl_proveedor_id_prov`) REFERENCES `tbl_proveedor` (`id_prov`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_compras`
--

LOCK TABLES `tbl_compras` WRITE;
/*!40000 ALTER TABLE `tbl_compras` DISABLE KEYS */;
INSERT INTO `tbl_compras` VALUES (1,'2023-10-26','2023-10-27','Contabilidad',500.20,15.20,515.20,'Mi primera compra yeiiii',1,1,'2024-05-12',1),(2,'2024-05-03','2024-05-03','Compras',984.00,118.08,1102.08,'',2,0,'2024-05-03',6),(3,'2024-05-03','2024-05-03','Logística',12350.00,1482.00,13832.00,'Quiero jugar jueguitos ',7,1,'2024-06-26',7),(70,'2024-05-20','2024-05-21','Compras',100.00,15.00,115.00,'Notas de la compra',2,1,'2024-05-25',3),(71,'2024-05-23','2024-06-28','Inventario',400000.00,48000.00,448000.00,'Se ha completado la compra ¨MODIFICADO',10,1,'2024-07-30',71);
/*!40000 ALTER TABLE `tbl_compras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_conceptomovimientodebancos`
--

DROP TABLE IF EXISTS `tbl_conceptomovimientodebancos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_conceptomovimientodebancos` (
  `id_conceptoMovimiento` int NOT NULL AUTO_INCREMENT,
  `concepto_movimientoBanco` varchar(30) NOT NULL,
  `efecto_movimientoBanco` varchar(2) NOT NULL,
  `estado_movimientoBanco` varchar(30) NOT NULL,
  PRIMARY KEY (`id_conceptoMovimiento`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_conceptomovimientodebancos`
--

LOCK TABLES `tbl_conceptomovimientodebancos` WRITE;
/*!40000 ALTER TABLE `tbl_conceptomovimientodebancos` DISABLE KEYS */;
INSERT INTO `tbl_conceptomovimientodebancos` VALUES (1,'Deposito','+','Activo'),(2,'Retiro','-','Activo'),(3,'Prueba','+','Activo'),(4,'Prueba','+','Activo'),(5,'Prueba','+','Activo');
/*!40000 ALTER TABLE `tbl_conceptomovimientodebancos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_conciliacion_bancaria`
--

DROP TABLE IF EXISTS `tbl_conciliacion_bancaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_conciliacion_bancaria` (
  `pk_conb_id_conciliacion` int NOT NULL AUTO_INCREMENT,
  `conb_anio_conciliacion` varchar(100) DEFAULT NULL,
  `conb_mes_conciliacion` varchar(100) DEFAULT NULL,
  `fk_conb_mov_libro` float NOT NULL,
  `fk_conb_estatusConc` int NOT NULL,
  `conb_mov_conciliacion` float DEFAULT NULL,
  `conb_saldo_final` float DEFAULT NULL,
  `conb_status` int DEFAULT NULL,
  PRIMARY KEY (`pk_conb_id_conciliacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_conciliacion_bancaria`
--

LOCK TABLES `tbl_conciliacion_bancaria` WRITE;
/*!40000 ALTER TABLE `tbl_conciliacion_bancaria` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_conciliacion_bancaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_cotizaciones`
--

DROP TABLE IF EXISTS `tbl_cotizaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_cotizaciones` (
  `No_Cotizacion` int NOT NULL,
  `fecha_coti` date NOT NULL,
  `fechaFinal_coti` date NOT NULL,
  `Solicitud` varchar(45) NOT NULL,
  PRIMARY KEY (`No_Cotizacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_cotizaciones`
--

LOCK TABLES `tbl_cotizaciones` WRITE;
/*!40000 ALTER TABLE `tbl_cotizaciones` DISABLE KEYS */;
INSERT INTO `tbl_cotizaciones` VALUES (0,'2024-05-03','2024-05-18','Pedido'),(1,'2024-05-03','2024-05-18','Pedido'),(2,'2024-05-03','2024-05-18','Pedido'),(3,'2024-05-03','2024-05-18','Pedido'),(4,'2024-05-09','2024-05-24','Pedido'),(5,'2024-05-09','2024-05-24','Pedido'),(6,'2024-05-09','2024-05-24','Pedido'),(7,'2024-05-11','2024-05-26','Pedido'),(8,'2024-05-11','2024-05-26','Pedido'),(9,'2024-05-15','2024-05-30','Pedido'),(10,'2024-05-18','2024-06-02','Pedido'),(11,'2024-05-17','2024-05-19','Cotizacion'),(12,'2024-05-18','2024-06-02','Pedido'),(13,'2024-05-22','2024-06-06','Pedido'),(14,'2024-05-23','2024-06-07','Pedido'),(15,'2024-05-23','2024-06-07','Pedido');
/*!40000 ALTER TABLE `tbl_cotizaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_cuentabancaria`
--

DROP TABLE IF EXISTS `tbl_cuentabancaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_cuentabancaria` (
  `id_cuentaBancaria` int NOT NULL AUTO_INCREMENT,
  `nombre_empresa` varchar(30) NOT NULL,
  `id_bancoAsociado` int NOT NULL,
  `tipo_cuenta` varchar(30) NOT NULL,
  `numero_cuenta` varchar(30) NOT NULL,
  `saldoDisponible` double NOT NULL,
  `reserva` double DEFAULT '0',
  `fecha_apertura` date NOT NULL,
  `estado_cuenta` varchar(20) NOT NULL,
  `tipo_moneda` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id_cuentaBancaria`),
  KEY `id_bancoAsociado` (`id_bancoAsociado`),
  CONSTRAINT `tbl_cuentabancaria_ibfk_1` FOREIGN KEY (`id_bancoAsociado`) REFERENCES `tbl_banco` (`id_banco`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_cuentabancaria`
--

LOCK TABLES `tbl_cuentabancaria` WRITE;
/*!40000 ALTER TABLE `tbl_cuentabancaria` DISABLE KEYS */;
INSERT INTO `tbl_cuentabancaria` VALUES (1,'Carrillo FC',3,'Monetaria','3201',152942,1030.4,'2024-04-12','Activo','Dollar'),(2,'Bytech SA',4,'Monetaria','8765',504500,448000,'2024-04-12','Activo','Euro');
/*!40000 ALTER TABLE `tbl_cuentabancaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detalle_cotizacion`
--

DROP TABLE IF EXISTS `tbl_detalle_cotizacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detalle_cotizacion` (
  `id_detalle_cotizacion` int NOT NULL AUTO_INCREMENT,
  `tbl_clientes_id_cliente` int NOT NULL,
  `cantidad_coti` int NOT NULL,
  `tbl_cotizaciones_No_Cotizacion` int NOT NULL,
  `tbl_producto_cod_producto` int NOT NULL,
  `total_detCoti` double NOT NULL,
  PRIMARY KEY (`id_detalle_cotizacion`),
  KEY `fk_tbl_detalle_cotizacion_tbl_clientes1_idx` (`tbl_clientes_id_cliente`),
  KEY `fk_tbl_detalle_cotizacion_tbl_cotizaciones1_idx` (`tbl_cotizaciones_No_Cotizacion`),
  KEY `fk_tbl_detalle_cotizacion_tbl_producto1_idx` (`tbl_producto_cod_producto`),
  CONSTRAINT `fk_tbl_detalle_cotizacion_tbl_clientes1` FOREIGN KEY (`tbl_clientes_id_cliente`) REFERENCES `tbl_clientes` (`id_cliente`),
  CONSTRAINT `fk_tbl_detalle_cotizacion_tbl_cotizaciones1` FOREIGN KEY (`tbl_cotizaciones_No_Cotizacion`) REFERENCES `tbl_cotizaciones` (`No_Cotizacion`),
  CONSTRAINT `fk_tbl_detalle_cotizacion_tbl_producto1` FOREIGN KEY (`tbl_producto_cod_producto`) REFERENCES `tbl_producto` (`cod_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=105 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detalle_cotizacion`
--

LOCK TABLES `tbl_detalle_cotizacion` WRITE;
/*!40000 ALTER TABLE `tbl_detalle_cotizacion` DISABLE KEYS */;
INSERT INTO `tbl_detalle_cotizacion` VALUES (61,13,1,0,1,7500),(62,13,2,0,1,7500),(63,2,10,1,2,73500),(64,337,1,2,12,10123),(65,337,4,2,1,10123),(66,3,2,3,1,5615),(67,3,5,3,12,5615),(68,339,1,4,1,10000),(69,339,3,4,1,10000),(70,340,1,5,1,5000),(71,340,1,5,1,5000),(72,341,1,6,1,7500),(73,341,1,6,1,7500),(74,341,1,6,1,7500),(75,342,1,7,1,90700),(76,342,12,7,2,90700),(77,343,5,8,1,12500),(78,344,1,9,1,17200),(79,344,1,9,2,17200),(80,344,1,9,2,17200),(93,357,1,10,1,5000),(94,357,1,10,1,5000),(97,360,1,12,1,39250),(98,360,5,12,2,39250),(99,361,1,13,2,7965),(100,361,5,13,12,7965),(101,362,100,14,3,200000),(102,362,100,14,4,200000),(103,364,10,15,1,98500),(104,364,10,15,2,98500);
/*!40000 ALTER TABLE `tbl_detalle_cotizacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detallecompras`
--

DROP TABLE IF EXISTS `tbl_detallecompras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detallecompras` (
  `id_detalleCompra` int NOT NULL,
  `cantidad_compra_det` int NOT NULL,
  `totalPorProducto_det` double NOT NULL,
  `tbl_Producto_cod_producto` int NOT NULL,
  `tbl_Encabezado_Compras_id_EncComp` int NOT NULL,
  PRIMARY KEY (`id_detalleCompra`),
  KEY `fk_tbl_detalleCompras_tbl_Producto1_idx` (`tbl_Producto_cod_producto`),
  KEY `fk_tbl_detalleCompras_tbl_Encabezado_Compras1_idx` (`tbl_Encabezado_Compras_id_EncComp`),
  CONSTRAINT `fk_tbl_detalleCompras_tbl_Encabezado_Compras1` FOREIGN KEY (`tbl_Encabezado_Compras_id_EncComp`) REFERENCES `tbl_compras` (`id_EncComp`),
  CONSTRAINT `fk_tbl_detalleCompras_tbl_Producto1` FOREIGN KEY (`tbl_Producto_cod_producto`) REFERENCES `tbl_producto` (`cod_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detallecompras`
--

LOCK TABLES `tbl_detallecompras` WRITE;
/*!40000 ALTER TABLE `tbl_detallecompras` DISABLE KEYS */;
INSERT INTO `tbl_detallecompras` VALUES (1,2,3,1,1),(2,8,984,12,2),(3,2,5000,1,3),(4,1,7350,2,3),(5,200,200000,3,71),(6,200,200000,4,71);
/*!40000 ALTER TABLE `tbl_detallecompras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detallefacturaxpagar`
--

DROP TABLE IF EXISTS `tbl_detallefacturaxpagar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detallefacturaxpagar` (
  `id_detalleFac` int NOT NULL AUTO_INCREMENT,
  `cantidad_detalleFac` int NOT NULL,
  `totalPorProducto_detalleFac` double NOT NULL,
  `tbl_facturaXPagar_NoFactura` int NOT NULL,
  `tbl_Producto_cod_producto` int NOT NULL,
  PRIMARY KEY (`id_detalleFac`),
  KEY `fk_tbl_detalleFacturaXPagar_tbl_facturaXPagar1_idx` (`tbl_facturaXPagar_NoFactura`),
  KEY `fk_tbl_detalleFacturaXPagar_tbl_Producto1_idx` (`tbl_Producto_cod_producto`),
  CONSTRAINT `fk_tbl_detalleFacturaXPagar_tbl_facturaXPagar1` FOREIGN KEY (`tbl_facturaXPagar_NoFactura`) REFERENCES `tbl_facturaxpagar` (`NoFactura`),
  CONSTRAINT `fk_tbl_detalleFacturaXPagar_tbl_Producto1` FOREIGN KEY (`tbl_Producto_cod_producto`) REFERENCES `tbl_producto` (`cod_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detallefacturaxpagar`
--

LOCK TABLES `tbl_detallefacturaxpagar` WRITE;
/*!40000 ALTER TABLE `tbl_detallefacturaxpagar` DISABLE KEYS */;
INSERT INTO `tbl_detallefacturaxpagar` VALUES (1,2,3,1,1),(2,2,5000,2,1),(3,1,7350,2,2),(4,200,200000,55555,3),(5,200,200000,55555,4);
/*!40000 ALTER TABLE `tbl_detallefacturaxpagar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detallemovpro`
--

DROP TABLE IF EXISTS `tbl_detallemovpro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detallemovpro` (
  `id_detalleMovP` int NOT NULL AUTO_INCREMENT,
  `noFactura` int NOT NULL,
  `banco_MovP` varchar(45) COLLATE utf8mb4_general_ci NOT NULL,
  `tipo_MovP` varchar(45) COLLATE utf8mb4_general_ci NOT NULL,
  `numero_MovP` varchar(45) COLLATE utf8mb4_general_ci NOT NULL,
  `concepto_MovP` varchar(45) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id_detalleMovP`),
  KEY `noFactura_idx` (`noFactura`),
  CONSTRAINT `noFactura` FOREIGN KEY (`noFactura`) REFERENCES `tbl_facturaxpagar` (`NoFactura`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detallemovpro`
--

LOCK TABLES `tbl_detallemovpro` WRITE;
/*!40000 ALTER TABLE `tbl_detallemovpro` DISABLE KEYS */;
INSERT INTO `tbl_detallemovpro` VALUES (1,1,'Banco Industrial','mov varios','12312412124214','pago por compra de carros'),(2,2,'Banco Industrial','Pago a Proveedores','5864','Pago de fact numero 2 perteneciente a Antonio'),(3,2,'Banco Industrial','Pago a Proveedores','547562','Pago de la factura 2'),(4,2,'Banco Industrial','mov varios','12412','pago a fact'),(5,2,'Banco Industrial','Pago a Proveedores','86728431','pago factura numero 2'),(14,2,'BAM','Pago a Proveedores','456434','pago factura 2'),(15,2,'Banrural','Pago','112543','Pago de facturas'),(16,2,'Banrural','Pago','112543','Pago de facturas'),(17,2,'BAM','Pago a Proveedores','512341','pagos de facturas 2 y 3'),(18,3,'BAM','Pago a Proveedores','512341','pagos de facturas 2 y 3'),(19,55555,'BAM','Pago a Proveedores','52463','Pago de factura 55555');
/*!40000 ALTER TABLE `tbl_detallemovpro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detalleordenescompra`
--

DROP TABLE IF EXISTS `tbl_detalleordenescompra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detalleordenescompra` (
  `id_detalle` int NOT NULL AUTO_INCREMENT,
  `OrdenesCompra_id_OrdComp` int NOT NULL,
  `cantidad_det` int NOT NULL,
  `totalProducto_det` double NOT NULL,
  `tbl_Producto_cod_producto` int NOT NULL,
  PRIMARY KEY (`id_detalle`),
  KEY `fk_DetalleOrdenesCompra_OrdenesCompra_idx` (`OrdenesCompra_id_OrdComp`),
  KEY `fk_tbl_DetalleOrdenesCompra_tbl_Producto1_idx` (`tbl_Producto_cod_producto`),
  CONSTRAINT `fk_DetalleOrdenesCompra_OrdenesCompra` FOREIGN KEY (`OrdenesCompra_id_OrdComp`) REFERENCES `tbl_ordenescompra` (`id_OrdComp`),
  CONSTRAINT `fk_tbl_DetalleOrdenesCompra_tbl_Producto1` FOREIGN KEY (`tbl_Producto_cod_producto`) REFERENCES `tbl_producto` (`cod_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detalleordenescompra`
--

LOCK TABLES `tbl_detalleordenescompra` WRITE;
/*!40000 ALTER TABLE `tbl_detalleordenescompra` DISABLE KEYS */;
INSERT INTO `tbl_detalleordenescompra` VALUES (1,2,1,123,12),(2,2,2,5000,1),(5,4,2,5000,1),(6,5,2,5000,1),(7,8,2,5000,1),(8,71,200,200000,3),(9,71,200,200000,4);
/*!40000 ALTER TABLE `tbl_detalleordenescompra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detalletrasladoprod`
--

DROP TABLE IF EXISTS `tbl_detalletrasladoprod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detalletrasladoprod` (
  `id_detalletraslado` int NOT NULL AUTO_INCREMENT,
  `tbl_trasladoprod_id_trasladoprod` int NOT NULL,
  `tbl_Producto_cod_producto` int NOT NULL,
  `cantidad_traslado` varchar(45) NOT NULL,
  PRIMARY KEY (`id_detalletraslado`),
  KEY `fk_tbl_detalletrasladoprod_tbl_Producto1_idx` (`tbl_Producto_cod_producto`),
  CONSTRAINT `fk_tbl_detalletrasladoprod_tbl_Producto1` FOREIGN KEY (`tbl_Producto_cod_producto`) REFERENCES `tbl_producto` (`cod_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detalletrasladoprod`
--

LOCK TABLES `tbl_detalletrasladoprod` WRITE;
/*!40000 ALTER TABLE `tbl_detalletrasladoprod` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_detalletrasladoprod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detalleventas`
--

DROP TABLE IF EXISTS `tbl_detalleventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detalleventas` (
  `id_ventas_det` int NOT NULL,
  `fecha_venta_det` date NOT NULL,
  `tbl_Ventas_pedido_id_ventas_ped` int NOT NULL,
  PRIMARY KEY (`id_ventas_det`),
  KEY `tbl_Ventas_pedido_id_ventas_ped_idx` (`tbl_Ventas_pedido_id_ventas_ped`),
  CONSTRAINT `tbl_Ventas_pedido_id_ventas_ped` FOREIGN KEY (`tbl_Ventas_pedido_id_ventas_ped`) REFERENCES `tbl_ventaspedido` (`id_ventas_ped`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detalleventas`
--

LOCK TABLES `tbl_detalleventas` WRITE;
/*!40000 ALTER TABLE `tbl_detalleventas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_detalleventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_disponibilidaddiaria`
--

DROP TABLE IF EXISTS `tbl_disponibilidaddiaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_disponibilidaddiaria` (
  `id_disponibilidad` int NOT NULL AUTO_INCREMENT,
  `id_cuentaDisponibilidad` int NOT NULL,
  `id_bancoActual` int NOT NULL,
  `saldo_disponible` double NOT NULL,
  `saldo_consumido` double NOT NULL,
  `saldo_actual` double NOT NULL,
  `fecha_DisponibilidadDiaria` date NOT NULL,
  PRIMARY KEY (`id_disponibilidad`),
  KEY `id_cuentaDisponibilidad` (`id_cuentaDisponibilidad`),
  KEY `id_bancoActual` (`id_bancoActual`),
  CONSTRAINT `tbl_disponibilidaddiaria_ibfk_1` FOREIGN KEY (`id_cuentaDisponibilidad`) REFERENCES `tbl_cuentabancaria` (`id_cuentaBancaria`),
  CONSTRAINT `tbl_disponibilidaddiaria_ibfk_2` FOREIGN KEY (`id_bancoActual`) REFERENCES `tbl_banco` (`id_banco`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_disponibilidaddiaria`
--

LOCK TABLES `tbl_disponibilidaddiaria` WRITE;
/*!40000 ALTER TABLE `tbl_disponibilidaddiaria` DISABLE KEYS */;
INSERT INTO `tbl_disponibilidaddiaria` VALUES (1,1,3,99999,500,100499,'2024-04-26'),(2,1,3,99389,1055,100444,'2024-04-26'),(3,1,3,106389,1055,107444,'2024-04-26'),(4,1,3,168708,0,138076,'2024-04-26'),(5,1,3,169708,0,138576,'2024-04-26'),(6,2,4,49453,0,4500,'2024-04-26'),(7,2,4,1049453,0,504500,'2024-04-26');
/*!40000 ALTER TABLE `tbl_disponibilidaddiaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_encabezadomovpro`
--

DROP TABLE IF EXISTS `tbl_encabezadomovpro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_encabezadomovpro` (
  `id_enMovPro` int NOT NULL AUTO_INCREMENT,
  `id_prove` int NOT NULL,
  `fecha_MovPro` datetime NOT NULL,
  `total_MovPro` double NOT NULL,
  PRIMARY KEY (`id_enMovPro`),
  KEY `id_prove_idx` (`id_prove`),
  CONSTRAINT `id_prove` FOREIGN KEY (`id_prove`) REFERENCES `tbl_proveedor` (`id_prov`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_encabezadomovpro`
--

LOCK TABLES `tbl_encabezadomovpro` WRITE;
/*!40000 ALTER TABLE `tbl_encabezadomovpro` DISABLE KEYS */;
INSERT INTO `tbl_encabezadomovpro` VALUES (1,9,'2024-05-03 00:00:00',515.2),(2,7,'2024-05-03 00:00:00',13832),(3,7,'2024-05-07 00:00:00',13832),(4,7,'2024-05-11 00:00:00',13832),(5,7,'2024-05-11 00:00:00',13832),(14,7,'2024-05-18 00:00:00',13832),(15,1,'2024-05-17 00:00:00',1200),(16,1,'2024-05-17 00:00:00',1200),(17,7,'2024-05-18 00:00:00',35852),(18,10,'2024-05-23 00:00:00',448000);
/*!40000 ALTER TABLE `tbl_encabezadomovpro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_estados`
--

DROP TABLE IF EXISTS `tbl_estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_estados` (
  `pk_id_estado` int NOT NULL AUTO_INCREMENT,
  `est_info_estado` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `est_num_estado` int DEFAULT NULL,
  PRIMARY KEY (`pk_id_estado`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_estados`
--

LOCK TABLES `tbl_estados` WRITE;
/*!40000 ALTER TABLE `tbl_estados` DISABLE KEYS */;
INSERT INTO `tbl_estados` VALUES (1,'Activo',1),(2,'Eliminado',2),(3,'Modificado',3);
/*!40000 ALTER TABLE `tbl_estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_existencias`
--

DROP TABLE IF EXISTS `tbl_existencias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_existencias` (
  `id_existencias` int NOT NULL AUTO_INCREMENT,
  `tbl_sucursales_id_sucursal` int NOT NULL,
  `tbl_producto_id_producto` int NOT NULL,
  `cantidad` int NOT NULL,
  PRIMARY KEY (`id_existencias`),
  KEY `fk_tbl_existencias_tbl_sucursal1_idx` (`tbl_sucursales_id_sucursal`),
  KEY `fk_tbl_producto_idx` (`tbl_producto_id_producto`),
  CONSTRAINT `fk_tbl_existencias_tbl_sucursal` FOREIGN KEY (`tbl_sucursales_id_sucursal`) REFERENCES `tbl_sucursales` (`id_sucursal`),
  CONSTRAINT `fk_tbl_producto` FOREIGN KEY (`tbl_producto_id_producto`) REFERENCES `tbl_producto` (`cod_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_existencias`
--

LOCK TABLES `tbl_existencias` WRITE;
/*!40000 ALTER TABLE `tbl_existencias` DISABLE KEYS */;
INSERT INTO `tbl_existencias` VALUES (1,1,1,262),(2,1,2,266),(3,1,12,280),(4,1,3,100),(5,1,4,100);
/*!40000 ALTER TABLE `tbl_existencias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_facturaxcobrar`
--

DROP TABLE IF EXISTS `tbl_facturaxcobrar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_facturaxcobrar` (
  `NoFactura` int NOT NULL AUTO_INCREMENT,
  `total_facxcob` double NOT NULL,
  `tiempoPago_facxcob` varchar(45) NOT NULL,
  `estado_facxcob` varchar(45) NOT NULL,
  `tbl_Ventas_detalle_id_ventas_det` int NOT NULL,
  `tbl_Clientes_id_cliente` int NOT NULL,
  `fecha_factura` varchar(45) NOT NULL,
  `faltante_pago` double NOT NULL,
  PRIMARY KEY (`NoFactura`),
  KEY `fk_tbl_facturaXcobrar_tbl_Ventas_detalle1_idx` (`tbl_Ventas_detalle_id_ventas_det`),
  KEY `fk_tbl_FacturaXcobrar_tbl_Clientes1_idx` (`tbl_Clientes_id_cliente`),
  CONSTRAINT `fk_tbl_FacturaXcobrar_tbl_Clientes1` FOREIGN KEY (`tbl_Clientes_id_cliente`) REFERENCES `tbl_clientes` (`id_cliente`),
  CONSTRAINT `fk_tbl_facturaXcobrar_tbl_Ventas_detalle1` FOREIGN KEY (`tbl_Ventas_detalle_id_ventas_det`) REFERENCES `tbl_ventaspedido` (`id_ventas_ped`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_facturaxcobrar`
--

LOCK TABLES `tbl_facturaxcobrar` WRITE;
/*!40000 ALTER TABLE `tbl_facturaxcobrar` DISABLE KEYS */;
INSERT INTO `tbl_facturaxcobrar` VALUES (9,7500,'18/05/2024','Por Pagar',15,13,'',0),(10,73500,'18/05/2024','Por Pagar',16,2,'',0),(11,10123,'18/05/2024','Por Pagar',17,337,'',0),(12,5615,'18/05/2024','Por Pagar',18,3,'',0),(13,10000,'24/05/2024','Por Pagar',19,339,'',0),(14,5000,'2024-05-24','Por Pagar',20,340,'',0),(15,7500,'2024-05-24','Por Pagar',21,341,'',0),(16,90700,'2024-06-02','Por Pagar',22,342,'',0),(17,12500,'2024-06-02','Por Pagar',23,343,'',0),(18,17200,'2024-05-22','Por Pagar',24,344,'2024-05-12',0),(19,5000,'2024-05-25','Por Pagar',25,357,'2024-05-18',4800),(20,39250,'2024-06-02','Por Pagar',26,360,'2024-05-18',29000),(21,7965,'2024-06-06','FACTURA PAGADA',27,361,'2024-05-22',0),(22,200000,'2024-06-14','Por Pagar',28,362,'2024-05-23',100000),(23,7965,'2024-06-07','Por Pagar',27,361,'2024-05-23',7965),(24,98500,'2024-06-07','Por Pagar',30,364,'2024-05-23',89500);
/*!40000 ALTER TABLE `tbl_facturaxcobrar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_facturaxpagar`
--

DROP TABLE IF EXISTS `tbl_facturaxpagar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_facturaxpagar` (
  `NoFactura` int NOT NULL,
  `nombreprov_facxpag` varchar(45) NOT NULL,
  `nitprov_facxpag` varchar(20) NOT NULL,
  `fechavenc_facxpag` date NOT NULL,
  `fecha_abono` date NOT NULL,
  `subtotal_facxpag` decimal(10,2) DEFAULT NULL,
  `iva_facxpag` decimal(10,2) DEFAULT NULL,
  `totalfac_facxpag` decimal(10,2) DEFAULT NULL,
  `estado_facxpag` int NOT NULL,
  `notas_facxpag` varchar(45) DEFAULT NULL,
  `tbl_Encabezado_Compras_id_EncComp` int NOT NULL,
  PRIMARY KEY (`NoFactura`),
  KEY `fk_tbl_facturaXPagar_tbl_Encabezado_Compras1_idx` (`tbl_Encabezado_Compras_id_EncComp`),
  CONSTRAINT `fk_tbl_facturaXPagar_tbl_Encabezado_Compras1` FOREIGN KEY (`tbl_Encabezado_Compras_id_EncComp`) REFERENCES `tbl_compras` (`id_EncComp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_facturaxpagar`
--

LOCK TABLES `tbl_facturaxpagar` WRITE;
/*!40000 ALTER TABLE `tbl_facturaxpagar` DISABLE KEYS */;
INSERT INTO `tbl_facturaxpagar` VALUES (1,'otto','12412','2024-05-12','2024-05-03',500.20,15.20,515.20,0,'',1),(2,'Antonio','123123','2024-06-26','2024-05-03',12350.00,1482.00,13832.00,1,'Gta6 listo',3),(3,'Antonio','123123','2024-05-24','2024-05-18',21500.00,520.00,22020.00,1,'Pagar',3),(70,'Proveedor XYZ','123456789012345','2024-05-20','2024-05-21',750.00,18.00,885.00,1,'Notas de la factura',3),(55555,'Proveedor Examen','5764253','2024-07-30','2024-05-23',400000.00,48000.00,448000.00,1,'Factura para Andrea',71);
/*!40000 ALTER TABLE `tbl_facturaxpagar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_lineas`
--

DROP TABLE IF EXISTS `tbl_lineas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lineas` (
  `id_linea` int NOT NULL AUTO_INCREMENT,
  `nombre_linea` varchar(45) NOT NULL,
  PRIMARY KEY (`id_linea`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lineas`
--

LOCK TABLES `tbl_lineas` WRITE;
/*!40000 ALTER TABLE `tbl_lineas` DISABLE KEYS */;
INSERT INTO `tbl_lineas` VALUES (1,'Tecnología'),(2,'Jugueteria');
/*!40000 ALTER TABLE `tbl_lineas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_marcas`
--

DROP TABLE IF EXISTS `tbl_marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_marcas` (
  `id_marca` int NOT NULL AUTO_INCREMENT,
  `nombre_marca` varchar(45) NOT NULL,
  PRIMARY KEY (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_marcas`
--

LOCK TABLES `tbl_marcas` WRITE;
/*!40000 ALTER TABLE `tbl_marcas` DISABLE KEYS */;
INSERT INTO `tbl_marcas` VALUES (1,'DELL'),(2,'HP'),(3,'Lenovo'),(4,'DELL'),(5,'Microsoft');
/*!40000 ALTER TABLE `tbl_marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_modulos`
--

DROP TABLE IF EXISTS `tbl_modulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_modulos` (
  `pk_id_modulos` int NOT NULL,
  `nombre_modulo` varchar(50) NOT NULL,
  `descripcion_modulo` varchar(150) NOT NULL,
  `estado_modulo` tinyint DEFAULT '0',
  PRIMARY KEY (`pk_id_modulos`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_modulos`
--

LOCK TABLES `tbl_modulos` WRITE;
/*!40000 ALTER TABLE `tbl_modulos` DISABLE KEYS */;
INSERT INTO `tbl_modulos` VALUES (1000,'SEGURIDAD','Seguridad',1),(8000,'PROTOTIPO ERP','ERP',1);
/*!40000 ALTER TABLE `tbl_modulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_movimiento_inv`
--

DROP TABLE IF EXISTS `tbl_movimiento_inv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_movimiento_inv` (
  `id_movimiento_inv` int NOT NULL AUTO_INCREMENT,
  `fecha_movimiento` date NOT NULL,
  `cantidad_movimiento` int NOT NULL,
  `descripcion_movimiento` varchar(45) NOT NULL,
  `tbl_movimientos_id_movimiento` int NOT NULL,
  `tbl_sucursales_id_sucursal` int NOT NULL,
  `tbl_Producto_cod_producto` int NOT NULL,
  PRIMARY KEY (`id_movimiento_inv`),
  KEY `fk_tbl_movimiento_inv_tbl_movimiento1_idx` (`tbl_movimientos_id_movimiento`),
  KEY `fk_tbl_movimiento_inv_tbl_sucursales1_idx` (`tbl_sucursales_id_sucursal`),
  KEY `fk_tbl_movimiento_inv_tbl_Producto1_idx` (`tbl_Producto_cod_producto`),
  CONSTRAINT `fk_tbl_movimiento_inv_tbl_movimiento1` FOREIGN KEY (`tbl_movimientos_id_movimiento`) REFERENCES `tbl_movimientos` (`id_movimiento`),
  CONSTRAINT `fk_tbl_movimiento_inv_tbl_Producto1` FOREIGN KEY (`tbl_Producto_cod_producto`) REFERENCES `tbl_producto` (`cod_producto`),
  CONSTRAINT `fk_tbl_movimiento_inv_tbl_sucursales1` FOREIGN KEY (`tbl_sucursales_id_sucursal`) REFERENCES `tbl_sucursales` (`id_sucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_movimiento_inv`
--

LOCK TABLES `tbl_movimiento_inv` WRITE;
/*!40000 ALTER TABLE `tbl_movimiento_inv` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_movimiento_inv` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_movimientodebancos`
--

DROP TABLE IF EXISTS `tbl_movimientodebancos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_movimientodebancos` (
  `id_movimientoBanco` int NOT NULL AUTO_INCREMENT,
  `tipo_movimientoBanco` int NOT NULL,
  `fecha_movimientoBanco` date NOT NULL,
  `monto_movimientoBanco` double NOT NULL,
  `cuenta_movimientoBanco` int NOT NULL,
  `efecto_movimientoBanco` varchar(5) NOT NULL,
  PRIMARY KEY (`id_movimientoBanco`),
  KEY `tipo_movimientoBanco` (`tipo_movimientoBanco`),
  KEY `cuenta_movimientoBanco` (`cuenta_movimientoBanco`),
  CONSTRAINT `tbl_movimientodebancos_ibfk_1` FOREIGN KEY (`tipo_movimientoBanco`) REFERENCES `tbl_conceptomovimientodebancos` (`id_conceptoMovimiento`),
  CONSTRAINT `tbl_movimientodebancos_ibfk_2` FOREIGN KEY (`cuenta_movimientoBanco`) REFERENCES `tbl_cuentabancaria` (`id_cuentaBancaria`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_movimientodebancos`
--

LOCK TABLES `tbl_movimientodebancos` WRITE;
/*!40000 ALTER TABLE `tbl_movimientodebancos` DISABLE KEYS */;
INSERT INTO `tbl_movimientodebancos` VALUES (1,1,'2024-04-11',500,1,''),(3,1,'2024-04-26',500,1,''),(4,2,'2024-04-26',555,1,''),(5,1,'2024-04-11',7000,1,''),(6,1,'2024-05-03',30632,1,'+'),(7,1,'2024-05-03',500,1,'+'),(8,1,'2024-04-11',12321,1,'+'),(10,1,'2024-05-11',1500,1,'+'),(99,1,'2024-05-19',5000,1,'P'),(100,1,'2024-05-19',5000,1,'P'),(101,1,'2024-05-23',500000,2,'+');
/*!40000 ALTER TABLE `tbl_movimientodebancos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_movimientos`
--

DROP TABLE IF EXISTS `tbl_movimientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_movimientos` (
  `id_movimiento` int NOT NULL AUTO_INCREMENT,
  `nombre_movimiento` varchar(45) NOT NULL,
  `descripcion_movimiento` varchar(45) NOT NULL,
  PRIMARY KEY (`id_movimiento`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_movimientos`
--

LOCK TABLES `tbl_movimientos` WRITE;
/*!40000 ALTER TABLE `tbl_movimientos` DISABLE KEYS */;
INSERT INTO `tbl_movimientos` VALUES (1,'Entrada','Entrada de producto'),(2,'Salida','Salida de producto'),(3,'Traslado','Traslado de producto entre sucursales');
/*!40000 ALTER TABLE `tbl_movimientos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_ordenescompra`
--

DROP TABLE IF EXISTS `tbl_ordenescompra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_ordenescompra` (
  `id_OrdComp` int NOT NULL AUTO_INCREMENT,
  `fechaSolicitid_OrdComp` date NOT NULL,
  `fechaEntrega_OrdComp` date NOT NULL,
  `deptoSolicitante_OrdComp` varchar(45) NOT NULL,
  `subTotal_OrdComp` decimal(10,2) DEFAULT NULL,
  `iva_OrdComp` decimal(10,2) DEFAULT NULL,
  `totalOrden_OrdComp` decimal(10,2) DEFAULT NULL,
  `notas_OrdComp` varchar(45) NOT NULL,
  `tbl_proveedor_id_prov` int NOT NULL,
  PRIMARY KEY (`id_OrdComp`),
  KEY `fk_tbl_OrdenesCompra_tbl_proveedor1_idx` (`tbl_proveedor_id_prov`),
  CONSTRAINT `fk_tbl_OrdenesCompra_tbl_proveedor1` FOREIGN KEY (`tbl_proveedor_id_prov`) REFERENCES `tbl_proveedor` (`id_prov`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_ordenescompra`
--

LOCK TABLES `tbl_ordenescompra` WRITE;
/*!40000 ALTER TABLE `tbl_ordenescompra` DISABLE KEYS */;
INSERT INTO `tbl_ordenescompra` VALUES (1,'2023-10-26','2023-10-27','Contabilidad',500.20,15.20,515.20,'Esta es la primer orden',1),(2,'2024-04-26','2024-04-28','Ventas',5123.00,614.76,5737.76,'Orden1',9),(3,'2024-04-26','2024-05-22','Compras',90700.00,10884.00,101584.00,'Muy caro',9),(4,'2024-04-30','2024-05-23','contabilidad',5000.00,600.00,5600.00,'Esta caro',9),(5,'2024-05-02','2024-05-02','venta',5000.00,600.00,5600.00,'',8),(6,'2024-05-03','2024-05-03','Compras',1230.00,147.60,1377.60,'',2),(7,'2024-05-03','2024-05-03','Logística',5369.00,644.28,6013.28,'',7),(8,'2024-05-18','2024-05-18','Compras',5000.00,600.00,5600.00,'',9),(70,'2024-05-20','2024-05-21','Departamento de Compras',500.00,12.00,560.00,'Notas de la orden de compra',2),(71,'2024-05-23','2024-06-28','Inventario',400000.00,48000.00,448000.00,'Productos Examen 400',10);
/*!40000 ALTER TABLE `tbl_ordenescompra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pagofact`
--

DROP TABLE IF EXISTS `tbl_pagofact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_pagofact` (
  `id_pagoFact` int NOT NULL AUTO_INCREMENT,
  `noFactura` int NOT NULL,
  `cliente` int NOT NULL,
  `banco` varchar(100) NOT NULL,
  `concepto` varchar(100) NOT NULL,
  `monto_pago` double NOT NULL,
  `extra_pago` double NOT NULL,
  `fecha_pago` varchar(45) NOT NULL,
  `NIT` varchar(45) NOT NULL,
  `num_recibo` varchar(45) NOT NULL,
  PRIMARY KEY (`id_pagoFact`),
  KEY `idcliente_idx` (`cliente`),
  KEY `noFacturas_idx` (`noFactura`),
  CONSTRAINT `FknoFactura` FOREIGN KEY (`noFactura`) REFERENCES `tbl_facturaxcobrar` (`NoFactura`),
  CONSTRAINT `idcliente` FOREIGN KEY (`cliente`) REFERENCES `tbl_clientes` (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_pagofact`
--

LOCK TABLES `tbl_pagofact` WRITE;
/*!40000 ALTER TABLE `tbl_pagofact` DISABLE KEYS */;
INSERT INTO `tbl_pagofact` VALUES (11,18,344,'Banco Industrial','a',200,0,'16/05/2024','cf','12312'),(12,18,344,'Banco Industrial','a',200,0,'16/05/2024','cf','9279817'),(13,18,344,'Banco Industrial','a',800,0,'16/05/2024','cf','9279817'),(14,18,344,'Banco Industrial','a',6000,0,'16/05/2024','cf','9279817'),(15,18,344,'Banco Industrial','pago de 200',6000,0,'16/05/2024','cf','9279817'),(16,18,344,'Banco Industrial','pago de 200',4000,0,'16/05/2024','cf','9279817'),(17,18,344,'Banco Industrial','pago de 200',4000,0,'16/05/2024','cf','9279817'),(18,18,344,'Banco Industrial','pago de 200',4000,0,'16/05/2024','cf','9279817'),(19,18,344,'Banco Industrial','pago',7200,0,'16/05/2024','','232131'),(20,17,343,'Banco Industrial','a',200,0,'16/05/2024','cf','2412412'),(21,17,343,'Banco Industrial','a',2300,0,'16/05/2024','cf','2412412'),(22,17,343,'Banco Industrial','a',10000,0,'16/05/2024','cf','2412412'),(23,17,343,'Banco Industrial','a',10000,0,'16/05/2024','cf','2412412'),(24,18,344,'Banco Industrial','xd',200,0,'18/05/2024','cf','412412'),(25,16,342,'Banco Industrial','xd',200,0,'18/05/2024','cf','412412'),(26,16,342,'Banco Industrial','xd',500,0,'18/05/2024','cf','412412'),(27,16,342,'Banco Industrial','xd',90000,0,'18/05/2024','cf','412412'),(28,18,344,'Banco Industrial','xd',1,0,'18/05/2024','cf','412412'),(29,19,357,'Banco Industrial','pago',200,0,'18/05/2024','','124'),(30,20,360,'Banco Industrial','pago parcial de 250',250,0,'18/05/2024','cf','155123'),(31,20,360,'Banco Industrial','pago parcial de 250',9000,0,'18/05/2024','cf','155123'),(32,20,360,'Banco Industrial','pago de 500',500,0,'21/05/2024','','142142'),(33,21,361,'Banco Industrial','pago de 965',965,0,'22/05/2024','cf','115252'),(34,21,361,'BAM','pago de 6000',6000,0,'22/05/2024','','1251512'),(35,21,361,'BAM','pago de 6000',1000,0,'22/05/2024','','1251512'),(36,22,362,'Banco Industrial','pago de 100k',100000,0,'23/05/2024','','1241'),(37,20,360,'Banco Industrial','pago de 500',500,0,'23/05/2024','cf','14124'),(38,24,364,'Banco Industrial','pago de 8500',8500,0,'23/05/2024','cf','41241'),(39,24,364,'Banco Industrial','pago de 500',500,0,'23/05/2024','cf','41241');
/*!40000 ALTER TABLE `tbl_pagofact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_perfiles`
--

DROP TABLE IF EXISTS `tbl_perfiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_perfiles` (
  `pk_id_perfil` int NOT NULL AUTO_INCREMENT,
  `nombre_perfil` varchar(50) NOT NULL,
  `descripcion_perfil` varchar(150) NOT NULL,
  `estado_perfil` tinyint DEFAULT '0',
  PRIMARY KEY (`pk_id_perfil`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_perfiles`
--

LOCK TABLES `tbl_perfiles` WRITE;
/*!40000 ALTER TABLE `tbl_perfiles` DISABLE KEYS */;
INSERT INTO `tbl_perfiles` VALUES (1,'ADMINISTRADOR','contiene todos los permisos del programa',1),(2,'SEGURIDAD','contiene todos los permisos de seguridad',1);
/*!40000 ALTER TABLE `tbl_perfiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permisosaplicacionesusuario`
--

DROP TABLE IF EXISTS `tbl_permisosaplicacionesusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permisosaplicacionesusuario` (
  `fk_id_aplicacion` int NOT NULL,
  `fk_id_usuario` int NOT NULL,
  `guardar_permiso` tinyint(1) DEFAULT '0',
  `modificar_permiso` tinyint(1) DEFAULT '0',
  `eliminar_permiso` tinyint(1) DEFAULT '0',
  `buscar_permiso` tinyint(1) DEFAULT '0',
  `imprimir_permiso` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`fk_id_aplicacion`,`fk_id_usuario`),
  KEY `fk_id_usuario` (`fk_id_usuario`),
  CONSTRAINT `tbl_permisosaplicacionesusuario_ibfk_1` FOREIGN KEY (`fk_id_aplicacion`) REFERENCES `tbl_aplicaciones` (`pk_id_aplicacion`),
  CONSTRAINT `tbl_permisosaplicacionesusuario_ibfk_2` FOREIGN KEY (`fk_id_usuario`) REFERENCES `tbl_usuarios` (`pk_id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permisosaplicacionesusuario`
--

LOCK TABLES `tbl_permisosaplicacionesusuario` WRITE;
/*!40000 ALTER TABLE `tbl_permisosaplicacionesusuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_permisosaplicacionesusuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permisosaplicacionperfil`
--

DROP TABLE IF EXISTS `tbl_permisosaplicacionperfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permisosaplicacionperfil` (
  `fk_id_perfil` int NOT NULL,
  `fk_id_aplicacion` int NOT NULL,
  `guardar_permiso` tinyint(1) DEFAULT '0',
  `modificar_permiso` tinyint(1) DEFAULT '0',
  `eliminar_permiso` tinyint(1) DEFAULT '0',
  `buscar_permiso` tinyint(1) DEFAULT '0',
  `imprimir_permiso` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`fk_id_perfil`,`fk_id_aplicacion`),
  KEY `fk_id_aplicacion` (`fk_id_aplicacion`),
  CONSTRAINT `tbl_permisosaplicacionperfil_ibfk_1` FOREIGN KEY (`fk_id_aplicacion`) REFERENCES `tbl_aplicaciones` (`pk_id_aplicacion`),
  CONSTRAINT `tbl_permisosaplicacionperfil_ibfk_2` FOREIGN KEY (`fk_id_perfil`) REFERENCES `tbl_perfiles` (`pk_id_perfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permisosaplicacionperfil`
--

LOCK TABLES `tbl_permisosaplicacionperfil` WRITE;
/*!40000 ALTER TABLE `tbl_permisosaplicacionperfil` DISABLE KEYS */;
INSERT INTO `tbl_permisosaplicacionperfil` VALUES (1,1000,1,1,1,1,1),(1,1001,1,1,1,1,1),(1,1002,1,1,1,1,1),(1,1003,1,1,1,1,1),(1,1004,1,1,1,1,1),(1,1101,1,1,1,1,1),(1,1102,1,1,1,1,1),(1,1103,1,1,1,1,1),(1,1201,1,1,1,1,1),(1,1301,1,1,1,1,1),(1,8000,1,1,1,1,1),(1,8001,1,1,1,1,1),(1,8002,1,1,1,1,1),(1,8003,1,1,1,1,1),(1,8004,1,1,1,1,1),(1,8005,1,1,1,1,1),(1,8006,1,1,1,1,1),(1,8007,1,1,1,1,1),(1,8008,1,1,1,1,1),(1,8009,1,1,1,1,1),(1,8010,1,1,1,1,1),(1,8011,1,1,1,1,1),(1,8012,1,1,1,1,1),(1,8013,1,1,1,1,1),(1,8014,1,1,1,1,1),(1,8015,1,1,1,1,1),(1,8016,1,1,1,1,1),(1,8017,1,1,1,1,1),(1,8018,1,1,1,1,1),(1,8019,1,1,1,1,1),(1,8020,1,1,1,1,1),(1,8021,1,1,1,1,1),(1,8022,1,1,1,1,1),(1,8023,1,1,1,1,1),(1,8024,1,1,1,1,1),(1,8030,1,1,1,1,1),(1,8031,1,1,1,1,1);
/*!40000 ALTER TABLE `tbl_permisosaplicacionperfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_producto`
--

DROP TABLE IF EXISTS `tbl_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_producto` (
  `cod_producto` int NOT NULL,
  `fecha_registro` date DEFAULT NULL,
  `nombre_prod` varchar(45) NOT NULL,
  `descripcion_prod` varchar(45) NOT NULL,
  `precioUnitario_prod` double NOT NULL,
  `tbl_marca_id_marca` int NOT NULL,
  `tbl_linea_id_linea` int NOT NULL,
  PRIMARY KEY (`cod_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_producto`
--

LOCK TABLES `tbl_producto` WRITE;
/*!40000 ALTER TABLE `tbl_producto` DISABLE KEYS */;
INSERT INTO `tbl_producto` VALUES (1,'2024-02-12','PC','tecnologia',2500,1,1),(2,'2024-02-12','RTX3090','Tarjeta Grafica',7350,3,1),(3,'2024-05-23','Producto1 Examen','producto para el examen',1000,1,1),(4,'2024-05-23','Producto2 Examen','2do prod Examen',1000,1,1),(12,'2024-04-26','Hotwheels','carro de juguete',123,3,2);
/*!40000 ALTER TABLE `tbl_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_proveedor`
--

DROP TABLE IF EXISTS `tbl_proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_proveedor` (
  `id_prov` int NOT NULL AUTO_INCREMENT,
  `nombre_prov` varchar(45) NOT NULL,
  `domicilio_prov` varchar(45) NOT NULL,
  `telefono_prov` varchar(45) NOT NULL,
  `nit_prov` varchar(20) NOT NULL,
  `estado_prov` varchar(45) NOT NULL,
  PRIMARY KEY (`id_prov`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_proveedor`
--

LOCK TABLES `tbl_proveedor` WRITE;
/*!40000 ALTER TABLE `tbl_proveedor` DISABLE KEYS */;
INSERT INTO `tbl_proveedor` VALUES (1,'otto','En frente de tilak futura','21114124','12412','activo'),(2,'alberto','Antigua Guatemala','151511525','412421421','Inactivo'),(3,'Mari','mixco viejo','1','14141241','Inactivo'),(7,'Antonio','Mixco','12312','123123','Inactivo'),(8,'asdas','ada','adsa','31231','Activo'),(9,'Jose','zona2','1241421','12412','Inactivo'),(10,'Proveedor Examen','zona2 de Mixco','86572431','5764253','Activo');
/*!40000 ALTER TABLE `tbl_proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_reportes`
--

DROP TABLE IF EXISTS `tbl_reportes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_reportes` (
  `pk_id_reporte` int NOT NULL AUTO_INCREMENT,
  `rep_correlativo` int DEFAULT NULL,
  `rep_nombre` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `fk_estado` int DEFAULT NULL,
  `rep_fecha` datetime DEFAULT NULL,
  `rep_archivo` varchar(600) DEFAULT NULL,
  `rep_fechaMod` datetime DEFAULT NULL,
  PRIMARY KEY (`pk_id_reporte`),
  UNIQUE KEY `rep_correlativo` (`rep_correlativo`),
  KEY `fk_estado` (`fk_estado`),
  CONSTRAINT `tbl_reportes_ibfk_1` FOREIGN KEY (`fk_estado`) REFERENCES `tbl_estados` (`pk_id_estado`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_reportes`
--

LOCK TABLES `tbl_reportes` WRITE;
/*!40000 ALTER TABLE `tbl_reportes` DISABLE KEYS */;
INSERT INTO `tbl_reportes` VALUES (21,1,'ReportedePagos.rpt',1,'2024-05-22 20:26:09','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReportedePagos.rpt',NULL),(22,2,'ReporteAutorizacionOrdenesCompra.rpt',1,'2024-05-22 20:26:51','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteAutorizacionOrdenesCompra.rpt',NULL),(23,3,'ReporteCompras.rpt',1,'2024-05-22 20:27:06','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteCompras.rpt',NULL),(24,4,'ReporteFacturas.rpt',1,'2024-05-22 20:27:26','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteFacturas.rpt',NULL),(25,5,'ReporteMovimientosDeBancos.rpt',1,'2024-05-22 20:27:47','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteMovimientosDeBancos.rpt',NULL),(26,6,'ReporteOrdenesdeCompra.rpt',1,'2024-05-22 20:28:09','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteOrdenesdeCompra.rpt',NULL),(27,7,'ReporteProveedores.rpt',1,'2024-05-22 20:28:35','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteProveedores.rpt',NULL),(28,8,'Reportetipocambio.rpt',1,'2024-05-22 20:28:51','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\Reportetipocambio.rpt',NULL),(29,9,'ReporteOperacionesProv.rpt',1,'2024-05-22 22:50:23','C:\\Users\\d_car\\OneDrive\\Documentos\\GitHub\\ProyectoMigracion\\ProyectoMigracion_G1\\Equipo1\\Codigo\\Componentes\\Reporteador\\CapaVista\\ReporteOperacionesProv.rpt',NULL);
/*!40000 ALTER TABLE `tbl_reportes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_sucursales`
--

DROP TABLE IF EXISTS `tbl_sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_sucursales` (
  `id_sucursal` int NOT NULL AUTO_INCREMENT,
  `nombre_sucursal` varchar(45) NOT NULL,
  `direccion_sucursal` varchar(45) NOT NULL,
  `telefono_sucursal` int NOT NULL,
  `correo_sucursal` varchar(45) NOT NULL,
  PRIMARY KEY (`id_sucursal`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_sucursales`
--

LOCK TABLES `tbl_sucursales` WRITE;
/*!40000 ALTER TABLE `tbl_sucursales` DISABLE KEYS */;
INSERT INTO `tbl_sucursales` VALUES (1,'sucursalSur','Monterico',12349829,'MSur@mail.com'),(2,'Sucursal Norte','Petén',98765432,'petensucu@gmail.com');
/*!40000 ALTER TABLE `tbl_sucursales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_tipocambio2`
--

DROP TABLE IF EXISTS `tbl_tipocambio2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_tipocambio2` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `moneda` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `venta` double DEFAULT NULL,
  `compra` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_tipocambio2`
--

LOCK TABLES `tbl_tipocambio2` WRITE;
/*!40000 ALTER TABLE `tbl_tipocambio2` DISABLE KEYS */;
INSERT INTO `tbl_tipocambio2` VALUES (1,'2024-05-01','Dólares de EE.UU.',7.77182,7.77182),(2,'2024-05-23','Dólares de EE.UU.',7.76412,7.76412),(3,'2024-05-23','Pesos Mexicanos',16.6777,16.6729);
/*!40000 ALTER TABLE `tbl_tipocambio2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_transacciones`
--

DROP TABLE IF EXISTS `tbl_transacciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_transacciones` (
  `id_transaccion` int NOT NULL AUTO_INCREMENT,
  `tipo_transaccion` varchar(50) DEFAULT NULL,
  `numero_transaccion` varchar(50) DEFAULT NULL,
  `fecha_transaccion` date DEFAULT NULL,
  `beneficiario_transaccion` varchar(100) DEFAULT NULL,
  `concepto_transaccion` varchar(255) DEFAULT NULL,
  `numero_factura` int DEFAULT NULL,
  PRIMARY KEY (`id_transaccion`),
  KEY `numero_factura` (`numero_factura`),
  CONSTRAINT `tbl_transacciones_ibfk_1` FOREIGN KEY (`numero_factura`) REFERENCES `tbl_facturaxpagar` (`NoFactura`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_transacciones`
--

LOCK TABLES `tbl_transacciones` WRITE;
/*!40000 ALTER TABLE `tbl_transacciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_transacciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_transprov`
--

DROP TABLE IF EXISTS `tbl_transprov`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_transprov` (
  `id_transprov` int NOT NULL AUTO_INCREMENT,
  `nombre_transprov` varchar(45) NOT NULL,
  `estado_transprov` varchar(45) NOT NULL,
  `tipo_transprov` varchar(20) NOT NULL,
  `tbl_proveedor_id_prov` int NOT NULL,
  PRIMARY KEY (`id_transprov`),
  KEY `fk_tbl_transprov_tbl_proveedor1_idx` (`tbl_proveedor_id_prov`),
  CONSTRAINT `fk_tbl_transprov_tbl_proveedor1` FOREIGN KEY (`tbl_proveedor_id_prov`) REFERENCES `tbl_proveedor` (`id_prov`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_transprov`
--

LOCK TABLES `tbl_transprov` WRITE;
/*!40000 ALTER TABLE `tbl_transprov` DISABLE KEYS */;
INSERT INTO `tbl_transprov` VALUES (2,'mov varios','Inactivo','Abono',2),(3,'mov especial','Activo','Cargo',3),(4,'Pago a Proveedores','Inactivo','Abono',2),(5,'nota de credito','Activo','Cargo',8);
/*!40000 ALTER TABLE `tbl_transprov` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_trasladoprod`
--

DROP TABLE IF EXISTS `tbl_trasladoprod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_trasladoprod` (
  `id_trasladoprod` int NOT NULL AUTO_INCREMENT,
  `fecha_traslado` date NOT NULL,
  `soliciante_traslado` varchar(45) DEFAULT NULL,
  `entregante_traslado` varchar(45) DEFAULT NULL,
  `tbl_sucursales_id_sucursal` int NOT NULL,
  PRIMARY KEY (`id_trasladoprod`),
  KEY `fk_tbl_trasladoprod_tbl_sucursales1_idx` (`tbl_sucursales_id_sucursal`),
  CONSTRAINT `fk_tbl_trasladoprod_tbl_Producto1` FOREIGN KEY (`tbl_sucursales_id_sucursal`) REFERENCES `tbl_sucursales` (`id_sucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_trasladoprod`
--

LOCK TABLES `tbl_trasladoprod` WRITE;
/*!40000 ALTER TABLE `tbl_trasladoprod` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_trasladoprod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_usuarios`
--

DROP TABLE IF EXISTS `tbl_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_usuarios` (
  `pk_id_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre_usuario` varchar(50) NOT NULL,
  `apellido_usuario` varchar(50) NOT NULL,
  `username_usuario` varchar(20) NOT NULL,
  `password_usuario` varchar(100) NOT NULL,
  `email_usuario` varchar(50) NOT NULL,
  `estado_usuario` tinyint NOT NULL DEFAULT '0',
  `pregunta` varchar(50) NOT NULL,
  `respuesta` varchar(50) NOT NULL,
  PRIMARY KEY (`pk_id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_usuarios`
--

LOCK TABLES `tbl_usuarios` WRITE;
/*!40000 ALTER TABLE `tbl_usuarios` DISABLE KEYS */;
INSERT INTO `tbl_usuarios` VALUES (1,'admin','admin','admin','HO0aGo4nM94=','esduardo@gmail.com',1,'COLOR FAVORITO','X9yc1/l1b2A=');
/*!40000 ALTER TABLE `tbl_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_vendedor`
--

DROP TABLE IF EXISTS `tbl_vendedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_vendedor` (
  `id_vendedor` int NOT NULL AUTO_INCREMENT,
  `nombre_vend` varchar(45) NOT NULL,
  `apellido_vend` varchar(45) NOT NULL,
  `telefono_vend` varchar(45) NOT NULL,
  `estado_vend` varchar(45) NOT NULL,
  PRIMARY KEY (`id_vendedor`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_vendedor`
--

LOCK TABLES `tbl_vendedor` WRITE;
/*!40000 ALTER TABLE `tbl_vendedor` DISABLE KEYS */;
INSERT INTO `tbl_vendedor` VALUES (5,'Lucas','hernandez','12124','Activo'),(6,'david','carrix','1231','Activo'),(8,'d','d','d','Activo'),(9,'v','v','v','Activo'),(10,'Otto','AventuraLopez','421231','Inactivo'),(11,'Lucia','Rojas','854362','Activo');
/*!40000 ALTER TABLE `tbl_vendedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_ventaspedido`
--

DROP TABLE IF EXISTS `tbl_ventaspedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_ventaspedido` (
  `id_ventas_ped` int NOT NULL AUTO_INCREMENT,
  `id_vendedor` int NOT NULL,
  `tbl_cotizaciones_No_Cotizacion` int NOT NULL,
  PRIMARY KEY (`id_ventas_ped`),
  KEY `fk_id_vendedor` (`id_vendedor`),
  KEY `tbl_cotizaciones_No_Cotizacion_idx` (`tbl_cotizaciones_No_Cotizacion`),
  CONSTRAINT `fk_id_vendedor` FOREIGN KEY (`id_vendedor`) REFERENCES `tbl_vendedor` (`id_vendedor`),
  CONSTRAINT `tbl_cotizaciones_No_Cotizacion` FOREIGN KEY (`tbl_cotizaciones_No_Cotizacion`) REFERENCES `tbl_cotizaciones` (`No_Cotizacion`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_ventaspedido`
--

LOCK TABLES `tbl_ventaspedido` WRITE;
/*!40000 ALTER TABLE `tbl_ventaspedido` DISABLE KEYS */;
INSERT INTO `tbl_ventaspedido` VALUES (15,6,0),(16,5,1),(17,5,2),(18,5,3),(19,5,4),(20,5,5),(21,5,6),(22,5,7),(23,5,8),(24,5,9),(25,5,10),(26,5,12),(27,5,13),(28,5,14),(29,5,14),(30,6,15);
/*!40000 ALTER TABLE `tbl_ventaspedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vista_clientes`
--

DROP TABLE IF EXISTS `vista_clientes`;
/*!50001 DROP VIEW IF EXISTS `vista_clientes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_clientes` AS SELECT 
 1 AS `ID_Cliente`,
 1 AS `Nombre`,
 1 AS `Apellido`,
 1 AS `Direccion`,
 1 AS `Correo`,
 1 AS `Telefono`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_cotizaciones`
--

DROP TABLE IF EXISTS `vista_cotizaciones`;
/*!50001 DROP VIEW IF EXISTS `vista_cotizaciones`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_cotizaciones` AS SELECT 
 1 AS `NoCotizacion`,
 1 AS `FechaCotizacion`,
 1 AS `ValidaHasta`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_detalle_cotizacion`
--

DROP TABLE IF EXISTS `vista_detalle_cotizacion`;
/*!50001 DROP VIEW IF EXISTS `vista_detalle_cotizacion`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_detalle_cotizacion` AS SELECT 
 1 AS `NoDetalleCotizacion`,
 1 AS `ClienteID`,
 1 AS `Cantidad`,
 1 AS `NoCotizacion`,
 1 AS `CodProducto`,
 1 AS `TotalCotizacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_operacionesprov`
--

DROP TABLE IF EXISTS `vista_operacionesprov`;
/*!50001 DROP VIEW IF EXISTS `vista_operacionesprov`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_operacionesprov` AS SELECT 
 1 AS `Id`,
 1 AS `NombreProveedor`,
 1 AS `Estado`,
 1 AS `TipodeMovimiento`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_producto`
--

DROP TABLE IF EXISTS `vista_producto`;
/*!50001 DROP VIEW IF EXISTS `vista_producto`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_producto` AS SELECT 
 1 AS `CodProducto`,
 1 AS `FechaRegistro`,
 1 AS `Nombre`,
 1 AS `Descripcion`,
 1 AS `PrecioUnitario`,
 1 AS `Marca`,
 1 AS `Linea`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `vista_clientes`
--

/*!50001 DROP VIEW IF EXISTS `vista_clientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_clientes` AS select `tbl_clientes`.`id_cliente` AS `ID_Cliente`,`tbl_clientes`.`nombre_cl` AS `Nombre`,`tbl_clientes`.`apellido_cl` AS `Apellido`,`tbl_clientes`.`direccion_cl` AS `Direccion`,`tbl_clientes`.`correo_cl` AS `Correo`,`tbl_clientes`.`telefono_cl` AS `Telefono` from `tbl_clientes` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_cotizaciones`
--

/*!50001 DROP VIEW IF EXISTS `vista_cotizaciones`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_cotizaciones` AS select `tbl_cotizaciones`.`No_Cotizacion` AS `NoCotizacion`,`tbl_cotizaciones`.`fecha_coti` AS `FechaCotizacion`,`tbl_cotizaciones`.`fechaFinal_coti` AS `ValidaHasta`,`tbl_cotizaciones`.`Solicitud` AS `Estado` from `tbl_cotizaciones` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_detalle_cotizacion`
--

/*!50001 DROP VIEW IF EXISTS `vista_detalle_cotizacion`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_detalle_cotizacion` AS select `tbl_detalle_cotizacion`.`id_detalle_cotizacion` AS `NoDetalleCotizacion`,`tbl_detalle_cotizacion`.`tbl_clientes_id_cliente` AS `ClienteID`,`tbl_detalle_cotizacion`.`cantidad_coti` AS `Cantidad`,`tbl_detalle_cotizacion`.`tbl_cotizaciones_No_Cotizacion` AS `NoCotizacion`,`tbl_detalle_cotizacion`.`tbl_producto_cod_producto` AS `CodProducto`,`tbl_detalle_cotizacion`.`total_detCoti` AS `TotalCotizacion` from `tbl_detalle_cotizacion` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_operacionesprov`
--

/*!50001 DROP VIEW IF EXISTS `vista_operacionesprov`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_operacionesprov` AS select `tbl_transprov`.`id_transprov` AS `Id`,`tbl_transprov`.`nombre_transprov` AS `NombreProveedor`,`tbl_transprov`.`estado_transprov` AS `Estado`,`tbl_transprov`.`tipo_transprov` AS `TipodeMovimiento` from `tbl_transprov` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_producto`
--

/*!50001 DROP VIEW IF EXISTS `vista_producto`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_producto` AS select `tbl_producto`.`cod_producto` AS `CodProducto`,`tbl_producto`.`fecha_registro` AS `FechaRegistro`,`tbl_producto`.`nombre_prod` AS `Nombre`,`tbl_producto`.`descripcion_prod` AS `Descripcion`,`tbl_producto`.`precioUnitario_prod` AS `PrecioUnitario`,`tbl_producto`.`tbl_marca_id_marca` AS `Marca`,`tbl_producto`.`tbl_linea_id_linea` AS `Linea` from `tbl_producto` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-23 21:10:13
