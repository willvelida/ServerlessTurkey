import React from 'react';
import axios from 'axios';

export default class TurkeyRecipe extends React.Component {
    state = {
        weight: '',
    };

    handleChange = event => {
        this.setState({
            weight: event.target.value
        });
    }

    handleSubmit = event => {
        event.preventDefault();

        const TurkeyWeightInput = {
            TurkeyWeightInPounds: this.state.weight
        };

        fetch(`http://localhost:7071/api/TurkeyRecipe`, {
            method: 'POST',
            body: JSON.stringify(TurkeyWeightInput)
        }).then(function(response) {
            console.log(response.json());
        })
    }

    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Turkey Weight In Lbs:
                        <input type="text" name="weight" onChange={this.handleChange} />
                    </label>
                    <button type="submit">Get recipe!</button>
                </form>
            </div>
        )
    }
}