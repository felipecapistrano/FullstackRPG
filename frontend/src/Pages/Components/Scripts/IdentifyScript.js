import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character1.png"
import Form from "../Form"
import useDataFetch from "../useDataFetch"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function IdentifyScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const data = {
        personagens: useDataFetch("/api/personagens/listar"),
    }
    console.log(data.personagens)

    const config = {
        initialValues: {
            Id: "",
        },
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [],
        select: [{
            id: "Id",
            titulo: "Nome",
            options: data.personagens
        }],
    }

    const text = [
        "Olá! Bem vindo(a) de volta.",
        "Pode se identificar por gentileza?",
        "",
        "Muito obrigada!"
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
            {form && data.personagens && 
                <Form
                config={config}
                />
            }
        </div>
    )
}

export default IdentifyScript