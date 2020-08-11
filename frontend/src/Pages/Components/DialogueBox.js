import React, {useState} from "react"
import TypeWriter from "./TypeWriter"
import "../../Styles/dialoguebox.css"

function DialogueBox (props) {
    const [textEnd, setTextEnd] = useState(false)

    return (
        <div id="dialogue-box" onClick={() => props.click()}>
            {textEnd && <p id="arrow"/>}
            {<TypeWriter end={(e) => setTextEnd(e)} text={props.text}/>}
        </div>
    )
}

export default DialogueBox