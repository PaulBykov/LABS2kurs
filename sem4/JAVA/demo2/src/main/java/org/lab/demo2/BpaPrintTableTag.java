package org.lab.demo2;


import org.lab.demo2.db.DbController;
import org.slf4j.ILoggerFactory;
import sun.rmi.runtime.Log;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.TagSupport;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.logging.Logger;

public class BpaPrintTableTag extends TagSupport {
    private String tableName;

    public void setTableName(String tableName) {
        this.tableName = tableName;
    }

    @Override
    public int doStartTag() throws JspException {
        JspWriter out = pageContext.getOut();
        Connection conn = null;
        Statement stmt = null;
        ResultSet rs = null;
        java.util.logging.Logger logger = Logger.getLogger(getClass().getName());

        try {
            DbController _controller = new DbController();
            _controller.Connect();
            conn = _controller.GetConn();

            logger.warning("getConn success ");

            stmt = conn.createStatement();
            String sql = "SELECT * FROM " + tableName;
            rs = stmt.executeQuery(sql);

            // Формирование HTML таблицы
            out.print("<table border='1'>");
            out.print("<tr>");
            int columnCount = rs.getMetaData().getColumnCount();
            for (int i = 1; i <= columnCount; i++) {
                out.print("<th>" + rs.getMetaData().getColumnName(i) + "</th>");
            }
            out.print("</tr>");

            while (rs.next()) {
                out.print("<tr>");
                for (int i = 1; i <= columnCount; i++) {
                    out.print("<td>" + rs.getString(i) + "</td>");
                }
                out.print("</tr>");
            }
            out.print("</table>");
        } catch (Exception e) {
            logger.warning("problems: " + e.getMessage());
            e.printStackTrace();
            throw new JspException(e.getMessage());
        } finally {
            try {
                if (rs != null) rs.close();
                if (stmt != null) stmt.close();
                if (conn != null) conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        return SKIP_BODY;
    }
}