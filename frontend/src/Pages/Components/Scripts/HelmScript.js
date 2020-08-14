import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character3.png"
import Form from "../Form"
import useDataFetch from "../useDataFetch"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function HelmScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const data = {
        materiais: useDataFetch("/api/materiais/listar"),
    }

    const config = {
        initialValues: {
            Nome: "",
            MaterialId:""
        },
        url: "/api/capacetes/salvar",
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [{
            id: "Nome",
            titulo: "Nome"
        }],
        select: [{
            id: "MaterialId",
            titulo: "Material",
            options: data.materiais
        }],
    }

    const text = [
        "Um capacete? Tudo bem.",
        "Como você quer esse seu capacete?",
        "",
        "Acredito que vai te proteger bem...",
        "Espero."
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
            {form && data.materiais && 
                <Form
                config={config}
                />
            }
        </div>
    )
}

export default HelmScript