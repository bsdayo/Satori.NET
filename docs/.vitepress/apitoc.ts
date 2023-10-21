import yaml from 'js-yaml'
import fs from 'fs'
import path from 'path'
import { DefaultTheme } from 'vitepress'

interface ApiTocNamespace {
  name: string
  href: string
  items: ApiTocItem[]
}

interface ApiTocItem {
  name: string
  href?: string
}

export function getApiNamespaces() {
  const apiTocPath = path.resolve(__dirname, '../api/toc.yml')
  const apiNamespaces = fs.existsSync(apiTocPath)
    ? (yaml.load(
        fs.readFileSync(apiTocPath, { encoding: 'utf-8' })
      ) as ApiTocNamespace[])
    : []
  return apiNamespaces
}

export function getApiSidebar(): DefaultTheme.SidebarItem[] {
  const apiNamespaces = getApiNamespaces()
  const sidebar: DefaultTheme.SidebarItem[] = []

  for (const namespace of apiNamespaces) {
    const sidebarItem: DefaultTheme.SidebarItem = {
      text: namespace.name,
      link: '/api/' + namespace.href,
      items: [],
    }

    let current: DefaultTheme.SidebarItem | undefined = undefined
    for (const item of namespace.items) {
      if (!item.href) {
        current = { text: item.name, items: [] }
        sidebarItem.items.push(current)
        continue
      }

      current?.items.push({
        text: item.name,
        link: '/api/' + item.href,
      })
    }

    sidebar.push(sidebarItem)
  }

  return sidebar
}
