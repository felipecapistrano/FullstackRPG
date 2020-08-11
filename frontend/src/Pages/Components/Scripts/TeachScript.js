import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character5.png"
import Form from "../Form"
import useDataFetch from "../useDataFetch"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function HelmScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const data = {
        personagens: useDataFetch("/api/personagens/listar"),
        habilidades: useDataFetch("/api/habilidades/listar")
    }

    const config = {
        initialValues: {
            Nome: "",
            MaterialId:""
        },
        url: "/api/personagemhabilidades/salvar",
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [],
        select: [{
            id: "PersonagemId",
            titulo: "Personagem",
            options: data.personagens
        },
        {
            id: "HabilidadeId",
            titulo: "Habilidades",
            options: data.habilidades
        }
    ]
    }

    const text = [
        "Certo.",
        "Escolha o que ensinar e para quem.",
        "",
        "Começarei o treinamento agora mesmo.",
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
            {form && data.personagens && data.habilidades && 
                <Form
                config={config}
                />
            }
        </div>
    )
}

export default HelmScript