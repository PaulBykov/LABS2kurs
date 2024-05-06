package org.example.demo1;

import java.io.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;


@WebServlet(name = "SetNumber", value = "/SetNumber")
public class SetNumber extends HttpServlet{
    private static final long serialVersionUID = 1L;

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        int newSecretNumber = Integer.parseInt(request.getParameter("number"));

        GuessNumber.overrideSecretNumber(newSecretNumber);
    }

}
