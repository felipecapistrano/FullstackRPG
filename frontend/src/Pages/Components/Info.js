import React, {useState} from "react"
import Sheet from "./Sheet"
import useDataFetch from "./useDataFetch"
import profile from "../../Assets/profile.png"
import "../../Styles/info.css"
import "../../Styles/form.css"

function Info () {
    const [clicked, setClicked] = useState(false)
    const data = {
        currentCharacter: useDataFetch("/api/personagens/buscar?id=" + localStorage.getItem("Id")),
        habilidades: useDataFetch("/api/habilidades/listar"),
        habilidadesPersonagem: useDataFetch("/api/personagemhabilidades/listar"),
        personagens: useDataFetch("/api/personagens/listar"),
        raças: useDataFetch("/api/raças/listar"),
        armas: useDataFetch("/api/armas/listar"),
        capacetes: useDataFetch("/api/capacetes/listar"),
        armaduras: useDataFetch("/api/armaduras/listar"),
    }
    return (
        <>
            <img onClick={() => setClicked(!clicked)} id="icon" src={profile} alt="icone"></img>
            {data.armaduras && clicked && <Sheet data={data}/>}
        </>
    )
}

export default Info