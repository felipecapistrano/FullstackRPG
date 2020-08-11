import React from "react"
import LinkButton from "./Buttons/LinkButton"
import "../../Styles/header.css"
import "../../Styles/buttons.css"

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