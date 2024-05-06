package org.lab.demo2.filters;

import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


@WebFilter(urlPatterns = {"/main/main.jsp"})
public class MainAccessFilter implements Filter {

    public void init(FilterConfig filterConfig) throws ServletException {
        // Инициализация фильтра
    }

    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
        HttpServletRequest httpRequest = (HttpServletRequest) request;
        HttpServletResponse httpResponse = (HttpServletResponse) response;

        // Получаем куки
        Cookie[] cookies = httpRequest.getCookies();
        boolean loginCookieFound = false;

        // Проверяем наличие и значение куки "login"
        if (cookies != null) {
            for (Cookie cookie : cookies) {
                if (cookie.getName().equals("login") && cookie.getValue() != null) {
                    loginCookieFound = true;
                    break;
                }
            }
        }


        if (!loginCookieFound) {
            httpResponse.sendRedirect(httpRequest.getContextPath() + "/error/errorPage.jsp");
            return;
        }

        // Продолжаем выполнение цепочки фильтров и сервлета
        chain.doFilter(request, response);
    }

    public void destroy() {
        // Уничтожение фильтра
    }
}
