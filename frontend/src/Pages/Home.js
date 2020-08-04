import React from "react"
import LinkButton from "./Components/Buttons/LinkButton"
import "./Styles/home.css"
import "./Styles/background.css"
import "./Styles/buttons.css"

function Home() {
    return (
        <div id="home">
            <div id="intro">
                <div id="intro-text">
                    <h1>Seja bem vindo(a) à cidade dos heróis</h1>
                    <div>
                        <LinkButton url={"/Plaza"} text={"Entrar na cidade"} classes={"scene-change-button"} element="home"/>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Home