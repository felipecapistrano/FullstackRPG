import React from "react"
import { useFormik } from "formik"
import api from "../../api"
import "../../Styles/form.css"

function Form (props) {
    const formik = useFormik({
        initialValues: props.config.initialValues,
        onSubmit: values => {
            try{
                props.config.url? api.post("https://localhost:44386" + props.config.url, values): localStorage.setItem("Id", values.Id)
            }catch (err) {
                alert("deu ruim")
            }
            props.config.finish(false)
        }})

    const input = props.config.input.map((e) => {
        return (
            <div key={e.Id} className="div-form">
                <label htmlFor={e.id}>{e.titulo}</label>
                <input
                    id={e.id}
                    name={e.id}
                    type="text"
                    onChange={formik.handleChange}
                    value={formik.values.id}
                />
            </div>
        )
    })

    const select = props.config.select.map((e) => {
        const options = e.options.map((e) => {return <option value={e.Id} key={e.Id}>{e.Nome}</option>})
        return (
            <div key={e.Id} className="div-form">
                <label htmlFor={e.id}>{e.titulo}</label>
                    <select id={e.id} name={e.id} onChange={formik.handleChange} value={formik.values.id}>
                        <option value=""></option>
                        {options}
                    </select>
            </div>
        )
    })

    return (
        <form className="form" onSubmit={formik.handleSubmit}>
            {input}
            {select}
            <button type="submit">Registrar</button>
        </form>
    )
}

export default Form