import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as User from '../store/User';

// At runtime, Redux will merge together...
type UserProps =
    User.UserState
    & typeof User.actionCreators
    & RouteComponentProps<{}>;

class UserPage extends React.Component<UserProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.getUsers();
    }

    public render() {
        return <div>
            <h1>Users</h1>
            <p></p>
            {this.renderUserTable()}
        </div>;
    }

    private renderUserTable() {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Ad</th>
                    <th>Soyad</th>
                    <th>Kullanıcı Adı</th>
                    
                </tr>
            </thead>
            <tbody>
                {
                    this.props.users.map(user =>
                        <tr key={user.Id}>
                            <td>{user.name}</td>
                            <td>{user.surname}</td>
                            <td>{user.userName}</td>
                        </tr>
                    )
                }
            </tbody>
        </table>;
    }
}

export default connect(
    (state: ApplicationState) => state.user, // Selects which state properties are merged into the component's props
    User.actionCreators                 // Selects which action creators are merged into the component's props
)(UserPage) as typeof UserPage;
