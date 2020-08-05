import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import Character from "../Character"
import character from "../../../Assets/character1.png"
import "../../Styles/script.css"
import "../../Styles/fade.css"

function RegisterScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const text = [
        "Ah! Deseja se cadastrar?",
        "Vou precisar que você preencha alguns dados para mim.",
    ]

    function script () {
        if(!text[currentText + 1]){
            props.end(false)
        }
        else
            setCurrentText(currentText + 1)
    }

    return (
        <div className="fadein">
            <Character image={character}/>
            <DialogueBox click={() => script()} text={text[currentText]}/>
            {form}
        </div>
    )
}

export default RegisterScript