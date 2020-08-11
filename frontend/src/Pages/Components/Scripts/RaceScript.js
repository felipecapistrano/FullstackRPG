import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character4.png"
import Form from "../Form"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function RaceScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const config = {
        initialValues: {
            Nome: "",
        },
        url: "/api/raças/salvar",
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [{
            id: "Nome",
            titulo: "Raça"
        }],
        select: [],
    }

    const text = [
        "Olá.",
        "Encontrou uma nova raça? Interessante. Conte-me mais.",
        "",
        "Interessante.",
    ]

    function script () {
        if (currentText === 1) {
            setForm(true)
            setCurrentText(currentText + 1)
        }
        else if (currentText === 2)
            return
        else if(!text[currentText + 1])
            props.end(false)
        else
            setCurrentText(currentText + 1)
    }

    return (
        <div className="fadein">
            <img src={character} alt="oi" id="character"></img>
            <DialogueBox click={() => script()} text={text[currentText]}/>
            {form && 
                <Form
                config={config}
                />
            }
        </div>
    )
}

export default RaceScript