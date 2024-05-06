import React from 'react';
import {Link} from "react-router-dom";

import "./style.css"
function Header() {
    return (
        <header className="header">
            <nav id="nav-menu">
                <Link to="/" className="nav-link">
                    <b className="link-text">На главную</b>
                </Link>
            </nav>

            <strong className="company-name"> PUZZLE MOVIES </strong>

            <div>
                follow us
            </div>
        </header>
    );
}

export default Header;