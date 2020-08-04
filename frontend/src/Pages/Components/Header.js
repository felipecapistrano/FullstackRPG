import React from "react"
import "../Styles/header.css"
import "../Styles/buttons.css"
import LinkButton from "./Buttons/LinkButton"

function Header() {
    return (
        <div id="header">
            <div>
                <img src="http://rpgroundtable.com/images/logo.png" alt="oi"></img>
            </div>
            <div id="header-links">
                {LinkButton("/", "Home", "header-button")}
                {LinkButton("/Guild", "Guilda", "header-button")}
                {LinkButton("/Forja", "Forja", "header-button")}
            </div>
        </div>
    )
}

export default Header