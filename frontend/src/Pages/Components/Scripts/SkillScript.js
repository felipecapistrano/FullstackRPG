import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character5.png"
import Form from "../Form"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function MaterialScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const config = {
        initialValues: {
            Nome: "",
            Descricao: ""
        },
        url: "/api/habilidades/salvar",
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [{
            id: "Nome",
            titulo: "Habilidade"
        },
        {
            id: "Descricao",
            titulo: "Descrição"
        },
        ],
        select: [],
    }

    const text = [
        "Seja bem-vindo!",
        "Dizes ser o detentor de uma habilidade que não conheço? Duvido.",
        "",
        "...",
        "Um verdadeiro mestre é um eterno aprendiz. Muito obrigado."
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

export default MaterialScript