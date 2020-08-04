import React from "react"
import {useHistory} from "react-router-dom"
import "../../Styles/fade.css"

function LinkButton (props) {
    const history = useHistory()

    function fadeout() {
        const element = document.getElementById(props.element)
        element.classList.remove("fadein")
        element.classList.add("fadeout")
        setTimeout(() => history.push(props.url), 800)
    }

    return (
        <button className={props.classes} onClick={() => fadeout()}>
            {props.text}
        </button>
    )
}

export default LinkButton