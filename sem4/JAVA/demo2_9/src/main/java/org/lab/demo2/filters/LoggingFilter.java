package org.lab.demo2.filters;


import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.util.logging.Logger;

@WebFilter("/*") // Применяем этот фильтр ко всем URL-адресам
public class LoggingFilter implements Filter {
    private static Logger logger;


    public void init(FilterConfig filterConfig) throws ServletException {
        logger = Logger.getLogger(LoggingFilter.class.getName());
    }

    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
        HttpServletRequest httpRequest = (HttpServletRequest) request;

        // Логгирование действия пользователя
        logger.info("Request URL: " + httpRequest.getRequestURL());
        logger.info("Servlet Path: " + httpRequest.getServletPath());
        logger.info("HTTP Method: " + httpRequest.getMethod());
        logger.info("Remote Address: " + httpRequest.getRemoteAddr());
        logger.info("Timestamp: " + System.currentTimeMillis());

        // Продолжаем выполнение цепочки фильтров и сервлета
        chain.doFilter(request, response);
    }

    public void destroy() {
        logger = null;
    }
}

