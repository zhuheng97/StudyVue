import request from '@/utils/request'

export function GetUserinfo(token) {
    return request({
        url: '/user/GetUserinfo',
        method: 'get',
        params: { token }
    })
}

export function SetUserInfo(data) {
    return request({
        url: '/user/SetUserInfo',
        method: 'post',
        data
    })
}
export function getColleaguesList(data) {
    return request({
        url: '/user/getColleaguesList',
        method: 'post',
        data
    })
}

export function FindColleagueByName(data) {
    return request({
        url: '/user/FindColleagueByName',
        method: 'post',
        data
    })
}

export function getStaffList(data) {
    return request({
        url: '/user/getStaffList',
        method: 'post',
        data
    })
}

export function SetStaffInfo(data) {
    return request({
        url: '/user/SetStaffInfo',
        method: 'post',
        data
    })
}