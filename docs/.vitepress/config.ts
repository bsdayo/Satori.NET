import { defineConfig } from 'vitepress'
import { getApiSidebar } from './apitoc'

// https://vitepress.vuejs.org/config/app-configs
export default defineConfig({
  lang: 'zh-CN',
  title: 'Satori.NET',
  description: 'Satori 协议 .NET SDK',
  base: '/Satori.NET/',

  themeConfig: {
    sidebar: {
      '/guide/': [
        {
          text: '指南',
          items: [
            { text: '简介', link: '/guide/index.md' },
            { text: '消息元素', link: '/guide/elements.md' },
          ],
        },
      ],
      '/api/': [{ text: 'API 参考', items: getApiSidebar() }],
    },
    nav: [
      { text: '指南', link: '/guide/' },
      { text: 'API 参考', link: '/api/' },
    ],
    socialLinks: [
      { icon: 'github', link: 'https://github.com/bsdayo/Satori.NET' },
    ],
  },
})
