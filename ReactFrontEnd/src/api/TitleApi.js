class TitleApi {
    static getAllTitles() {
        return fetch('http://localhost:2105/api/titlebasics').then(response =>{
            return response.json();
        }).catch(error => {
            return error;
        });
    }

    static searchTitles(search){
        return fetch('http://localhost:2105/api/titlebasics/'+ search).then(response => {
            return response.json();
        }).then((json) => { return json}).catch(error => {return error});
    }

    static getMoreTitles(start, end) {
        return fetch('http://localhost:2105/api/titlebasics/?startindex=' + start + '&pagesize=' + end).then(response => {
            return response.json();
        }).then((json) => { return json}).catch(error => {return error});
    }

    static getSingleTitle(id) {
        return fetch('http://localhost:2105/api/titlebasics/' + id).then(response => {
            return response.json().then(data => {return data[0]});
        }).catch(error => {
            return error;
        })
    }

    static putTitle(title){
        return fetch('http://localhost:2105/api/titlebasics/' + title.tconst, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({'tconst': title.tconst, 'titleType': title.titleType,
            'primaryTitle': title.primaryTitle, 'originalTitle': title.originalTitle, 'isAdult': title.isAdult,
            'startYear': title.startYear, 'endYear': title.endYear, 'runtimeMinutes': title.runtimeMinutes, 'genres': title.genres})
        }).then(response => { 
            return response.json().then(data => console.log(data))
        }).catch(error => {
            return error;
        })
    }

    static postTitle(title){
        return fetch('http://localhost:2105/api/titlebasics/', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({'tconst': title.tconst, 'titleType': title.titleType,
            'primaryTitle': title.primaryTitle, 'originalTitle': title.originalTitle, 'isAdult': title.isAdult,
            'startYear': title.startYear, 'endYear': title.endYear, 'runtimeMinutes': title.runtimeMinutes, 'genres': title.genres})
        }).then(response => { 
            return response.json().then(data => console.log(data))
        }).catch(error => {
            return error;
        })
    }

    static deleteTitle(id){
        return fetch('http://localhost:2105/api/titlebasics/' + id, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({'tconst': id})
        }).then(response => { 
            return response.json().then(data => console.log(data))
        }).catch(error => {
            return error;
        })
    }
}

export default TitleApi;