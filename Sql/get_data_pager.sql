-- ----------------------------
-- Procedure structure for get_data_pager
-- ----------------------------
DROP PROCEDURE IF EXISTS `get_data_pager`;
DELIMITER ;;
CREATE DEFINER=`app_user`@`%` PROCEDURE `get_data_pager`(  
    IN     p_table_name        VARCHAR(6000),          
    IN     p_fields            VARCHAR(6000),          
    IN     p_page_size         INT,                    
    IN     p_page_now          INT,                    
    IN     p_order_string      VARCHAR(512),             
    IN     p_where_string      VARCHAR(3000)             
)
    SQL SECURITY INVOKER
    COMMENT '分页存储过程'
BEGIN  
  
      
    DECLARE m_begin_row INT DEFAULT 0;  
    DECLARE m_limit_string CHAR(64);  
  
          
    SET m_begin_row = (p_page_now - 1) * p_page_size;  
    SET m_limit_string = CONCAT(' LIMIT ', m_begin_row, ', ', p_page_size);  
      
    SET @COUNT_STRING = CONCAT('SELECT COUNT(*) FROM ', p_table_name, ' ', p_where_string);  
    SET @MAIN_STRING = CONCAT('SELECT ', p_fields, ' FROM ', p_table_name, ' ', p_where_string, ' ', p_order_string, m_limit_string);  
  
      
    PREPARE count_stmt FROM @COUNT_STRING;  
    EXECUTE count_stmt;  
    DEALLOCATE PREPARE count_stmt;  
  
    PREPARE main_stmt FROM @MAIN_STRING;  
    EXECUTE main_stmt;  
    DEALLOCATE PREPARE main_stmt;  
      
END
;;
DELIMITER ;