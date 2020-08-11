import React, {useState} from "react"
import LinkButton from "./Components/Buttons/LinkButton"
import FadeIn from "react-fade-in"
import "../Styles/home.css"
import "../Styles/background.css"
import "../Styles/buttons.css"

function Home() {
    const [fadeout, setFadeout] = useState("")
    const [opacity, setOpacity] = useState({opacity: 0})
    const [fadein, setFadein] = useState("")

    function fade() {
        return setTimeout(() => {
            setOpacity()
            setFadeout("fadeout")
            setFadein("fadein")
        }, 6500)
    }
    fade()
    return (
        <>
            <div id="intro" className={fadeout}>
                <FadeIn delay={1500} transitionDuration={1000}>
                    <p className="intro-speech">Introdução genérica de mundo de fantasia</p>
                    <p className="intro-speech">Que ninguém presta atenção em nada do que está escrito</p>
                    <p className="intro-speech">E que todo mundo esquece 20 segundos depois de terminar</p>
                </FadeIn>
            </div>
            <div id="home" className={fadein} style={opacity}>
                <LinkButton classes="home-button" url="/Plaza" text="Entrar na cidade" element="home"/>
            </div>
        </>
    )
}

export default Home