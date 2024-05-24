
ALTER TABLE tbl_cuentaBancaria
ADD reserva DOUBLE DEFAULT 0 AFTER saldoDisponible;

CREATE VIEW vista_producto AS
SELECT 
    cod_producto AS CodProducto,
    fecha_registro AS FechaRegistro,
    nombre_prod AS Nombre,
    descripcion_prod AS Descripcion,
    precioUnitario_prod AS PrecioUnitario,
    tbl_marca_id_marca AS Marca,
    tbl_linea_id_linea AS Linea
FROM 
    tbl_producto;

  
ALTER TABLE tbl_ordenescompra
MODIFY COLUMN subTotal_OrdComp DECIMAL(10, 2),
MODIFY COLUMN iva_OrdComp DECIMAL(10, 2),
MODIFY COLUMN totalOrden_OrdComp DECIMAL(10, 2);

ALTER TABLE tbl_compras
MODIFY COLUMN subTotal_EncComp DECIMAL(10, 2),
MODIFY COLUMN iva_EncComp DECIMAL(10, 2),
MODIFY COLUMN totalOrden_EncComp DECIMAL(10, 2);

ALTER TABLE tbl_facturaxpagar
MODIFY COLUMN subtotal_facxpag DECIMAL(10, 2),
MODIFY COLUMN iva_facxpag DECIMAL(10, 2),
MODIFY COLUMN totalfac_facxpag DECIMAL(10, 2);



DROP TABLE IF EXISTS tbl_tipocambio;
CREATE TABLE tbl_tipocambio2 (
  id int(11) NOT NULL,
  fecha date DEFAULT NULL,
  moneda varchar(50) DEFAULT NULL,
  venta double DEFAULT NULL,
  compra double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;




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
  `rep_archivo` varchar(600) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `rep_fechaMod` datetime DEFAULT NULL,
  PRIMARY KEY (`pk_id_reporte`),
  UNIQUE KEY `rep_correlativo` (`rep_correlativo`),
  KEY `fk_estado` (`fk_estado`),
  CONSTRAINT `tbl_reportes_ibfk_1` FOREIGN KEY (`fk_estado`) REFERENCES `tbl_estados` (`pk_id_estado`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

UPDATE `bd_erp`.`tbl_aplicaciones` SET `nombre_aplicacion` = 'Pro. Operaciones Proveedores' WHERE (`pk_id_aplicacion` = '8013');