package org.lab.demo2.main;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Enumeration;
import java.util.Date;



@WebServlet(name="Main", value = "/Main")
public class Main extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");

        try {
            PrintWriter out = response.getWriter();

            out.println("<h1>Request Information: </h1>");
            out.println("<p>Version: " + request.getProtocol() + "</p>");
            out.println("<p>Client IP Address: " + request.getRemoteAddr() + "</p>");
            out.println("<p>Client Hostname: " + request.getRemoteHost() + "</p>");
            out.println("<p>HTTP Method: " + request.getMethod() + "</p>");
            out.println("<p>Request URI: " + request.getRequestURI() + "</p>");


            out.println("<h2>Request Headers:</h2>");
            out.println("<ul>");
            Enumeration<String> headerNames = request.getHeaderNames();
            while (headerNames.hasMoreElements()) {
                String headerName = headerNames.nextElement();
                out.println("<li>" + headerName + ": " + request.getHeader(headerName) + "</li>");
            }
            out.println("</ul>");

            Date currDate = new Date();
            currDate.setHours(currDate.getHours() + 3);
            response.addCookie(new Cookie("date", (currDate).toGMTString()));

            out.close();
        } catch (Exception e){
            response.sendError(506, "Exception during GET request: " + e.getMessage());
        }


    }
}
